using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class TCPClient : MonoBehaviour
{
    // SCRIPT INSTANCE //
    public static TCPClient Instance;

    // CLIENT OBJECT AND STREAM //
    TcpClient _client;
    NetworkStream _stream;

    // ISSERVER BOOL //
    public bool IsClient;

    private void Start()
    {
        Instance = this;
    }

    public void JoinServer()
    {
        Thread _thread = new(HandleServer);
        _thread.Start();

        IsClient = true;
    }

    void HandleServer()
    {
        // Create Client and Stream
        _client = new(Globals.Host, int.Parse(Globals.Port));
        _stream = _client.GetStream();
        SendMessageToServer($"Add Client:{Globals.Name}");

        // Read Data
        while (true)
        {
            byte[] _receivedData = new byte[256];
            _stream.Read(_receivedData, 0, _receivedData.Length);

            string _receivedMessage = System.Text.Encoding.ASCII.GetString(_receivedData);
            string[] _messageParts = _receivedMessage.Split(':');

            string _command = _messageParts[0];
            string _username = null;
            string _data = null;
            string _reply = null;

            if (_command.Equals("Default Message"))
            {
                _username = _messageParts[1];
                _data = _messageParts[2];
                
                UnityMainThreadDispatcher.Instance().Enqueue(() => ChatHistory.Instance.DisplayMessage(true, _username, GetInitials(_username), _data));
            }

            if (_command.Equals("Reply Message"))
            {
                _username = _messageParts[1];
                _data = _messageParts[2];
                _reply = _messageParts[3];

                UnityMainThreadDispatcher.Instance().Enqueue(() => ChatHistory.Instance.DisplayMessage(true, _username, GetInitials(_username), _data, _reply));
            }
        }
    }

    public void SendMessageToServer(string _message)
    {
        byte[] _data = System.Text.Encoding.ASCII.GetBytes(_message);
        _stream.Write(_data, 0, _data.Length);
    }

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
