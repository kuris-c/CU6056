using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class Client
{
    public TcpClient Tcp;
    public string Username;
    public string IpAddress;

    public Client(TcpClient _tcp, string _username, string _iPAddress) => (Tcp, Username, IpAddress) = (_tcp, _username, _iPAddress);
}

public class TCPServer : MonoBehaviour
{
    // SCRIPT INSTANCE //
    public static TCPServer Instance;

    // SERVER OBJECT //
    TcpListener _server;

    // CLIENT LIST //
    List<Client> _clientList = new();

    // ISSERVER BOOL //
    public bool IsServer;

    private void Start()
    {
        Instance = this;
    }

    public void MakeServer()
    {
        _server = new(IPAddress.Parse(Globals.Host), int.Parse(Globals.Port));
        _server.Start();

        Thread _thread = new(AcceptClients);
        _thread.Start();

        IsServer = true;
    }

    void AcceptClients()
    {
        while (true)
        {
            TcpClient _client = _server.AcceptTcpClient();

            Thread _clientThread = new(() => HandleClient(_client));
            _clientThread.Start();
        }
    }

    void HandleClient(TcpClient _client)
    {
        NetworkStream _stream = _client.GetStream();
        byte[] _receivedData = new byte[_client.ReceiveBufferSize];

        while ((_ = _stream.Read(_receivedData, 0, _receivedData.Length)) > 0)
        {
            string _receivedMessage = System.Text.Encoding.ASCII.GetString(_receivedData);
            string[] _messageParts = _receivedMessage.Split(':');
            string _command = _messageParts[0];
            string _data = _messageParts[1];

            if (_command.Equals("Add Client"))
            {
                string _username = _data;
                string _clientIpAddress = ((IPEndPoint)_client.Client.RemoteEndPoint).Address.ToString();
                _clientList.Add(new(_client, _username, _clientIpAddress));
            }

            else
            {
                // Compare Client IPAddress To List Of Stored Clients
                string _clientIpAddress = ((IPEndPoint)_client.Client.RemoteEndPoint).Address.ToString();
                Client _foundClient = _clientList.Find(client => client.IpAddress == _clientIpAddress);

                // Check If Client Was Found
                string _username = null;
                if (_foundClient != null)
                {
                    _username = _foundClient.Username;
                }

                if (_command.Equals("Default Message"))
                {
                    UnityMainThreadDispatcher.Instance().Enqueue(() => ChatHistory.Instance.DisplayMessage(true, _username, GetInitials(_username), _data));
                    BroadcastMessage(_foundClient, _receivedMessage);
                }
                
                if (_command.Equals("Reply Message"))
                {
                    string _reply = _messageParts[2];

                    UnityMainThreadDispatcher.Instance().Enqueue(() => ChatHistory.Instance.DisplayMessage(true, _username, GetInitials(_username), _data, _reply));
                    BroadcastMessage(_foundClient, _receivedMessage);
                }
            }
        }
    }

    // Send Data From Server To Client As A Message
    public void SendMessageToClient(string _message)
    {
        foreach (var _cli in _clientList)
        {
            NetworkStream _stream = _cli.Tcp.GetStream();
            byte[] _data = System.Text.Encoding.ASCII.GetBytes(_message);
            _stream.Write(_data, 0, _data.Length);
        }
    }

    public void BroadcastMessage(Client _client, string _message)
    {
        foreach (var _cli in _clientList)
        {
            if (_cli.Tcp != _client.Tcp)
            {
                NetworkStream _stream = _cli.Tcp.GetStream();
                byte[] _data = System.Text.Encoding.ASCII.GetBytes(_message);
                _stream.Write(_data, 0, _data.Length);
            }
        }    
    }

    // Get Initials
    private string GetInitials(string _input)
    {
        string _result = string.Empty;
        int _count = 0;

        foreach (char _c in _input)
        {
            if (!char.IsWhiteSpace(_c) && _c != '\0')
            {
                _result += _c;
                _count++;
            }

            if (_count == 2)
            {
                break;
            }
        }
        return _result;
    }
}
