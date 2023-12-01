using TMPro;
using UnityEngine;

public class InputMessage : MonoBehaviour
{
    private bool _isReplyingToMessage;
    private string _replyMessage;
    public TMP_InputField InputField;

    void Start()
    {
        InputField = GetComponent<TMP_InputField>();
        _isReplyingToMessage = false;

        InputField.onSubmit.AddListener(MessageSent);
    }

    public void IsReplyingToMessage(string _message, bool _isUnique)
    {
        if (_isUnique)
        {
            _isReplyingToMessage = true;
        }

        else
        {
            _isReplyingToMessage = false;
        }

        _replyMessage = _message;
    }

    private void MessageSent(string _message)
    {
        if (_isReplyingToMessage)
        {
            ChatHistory.Instance.DisplayMessage(false, Globals.Name, GetInitials(Globals.Name), _message, _replyMessage);

            if (TCPServer.Instance.IsServer)
            {
                TCPServer.Instance.SendMessageToClient($"Reply Message:{ Globals.Name}:{_replyMessage}:{_message}");
            }

            else if (TCPClient.Instance.IsClient)
            {
                TCPClient.Instance.SendMessageToServer($"Reply Message:{_replyMessage}:{_message}");
            }
        }

        else
        {
            ChatHistory.Instance.DisplayMessage(false, Globals.Name, GetInitials(Globals.Name), _message);

            if (TCPServer.Instance.IsServer)
            {
                TCPServer.Instance.SendMessageToClient($"Default Message:{ Globals.Name}:{_message}");
            }

            else if (TCPClient.Instance.IsClient)
            {
                TCPClient.Instance.SendMessageToServer($"Default Message:{_message}");
            }
        }

        InputField.text = null;
        InputField.Select();
        InputField.ActivateInputField();
        _isReplyingToMessage = false;
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