using UnityEngine;
using UnityEngine.EventSystems;

public class ChatHistory : MonoBehaviour, IScrollHandler
{
    [Header("Message Prefabs")]
    [SerializeField] private GameObject _incomingMessage;
    [SerializeField] private GameObject _incomingMessageNR;
    [SerializeField] private GameObject _outgoingMessage;
    [SerializeField] private GameObject _outgoingMessageNR;

    // SCROLL CHAT HISTORY VARIABLES //
    private RectTransform _rectTransform;
    private float _yPos;
    private float _height;
    private float _scrollSpeed = 20f;

    // INSTANCE //
    public static ChatHistory Instance;

    void Start()
    {
        _yPos = 100f;
        _rectTransform = GetComponent<RectTransform>();

        Instance = this;
    }

    public void OnScroll(PointerEventData eventData)
    {
        _height = _rectTransform.rect.height;

        if (_height >= 1000)
        {
            float delta = eventData.scrollDelta.y * _scrollSpeed;
            float diff = 900 - _height;

            if (delta < 0 && _yPos > diff)
            {
                _yPos += delta;
            }

            else if (delta > 0 && _yPos < 100)
            {
                _yPos += delta;
            }

            _yPos = Mathf.Clamp(_yPos, diff, 100);
            _rectTransform.anchoredPosition = new(_rectTransform.anchoredPosition.x, _yPos);
        }
    }

    public void DisplayMessage(bool _isIncoming, string _name, string _initials, string _content, string _replied = null)
    {
        GameObject _messageObj;

        if (_isIncoming)
        {
            if (_replied != null)
            {
                _messageObj = Instantiate(_incomingMessage, transform);
                ReplyMessage _messageObjScript = _messageObj.GetComponent<ReplyMessage>();

                _messageObjScript.Username.text = _name;
                _messageObjScript.Initials.text = _initials;
                _messageObjScript.MessageContent.text = _content;
                _messageObjScript.RepliedMessageContent.text = _replied;
            }

            else
            {
                _messageObj = Instantiate(_incomingMessageNR, transform);
                NoReplyMessage _messageObjScript = _messageObj.GetComponent<NoReplyMessage>();

                _messageObjScript.Username.text = _name;
                _messageObjScript.Initials.text = _initials;
                _messageObjScript.MessageContent.text = _content;
            }
        }

        else
        {
            if (_replied != null)
            {
                _messageObj = Instantiate(_outgoingMessage, transform);
                ReplyMessage _messageObjScript = _messageObj.GetComponent<ReplyMessage>();

                _messageObjScript.Username.text = _name;
                _messageObjScript.Initials.text = _initials;
                _messageObjScript.MessageContent.text = _content;
                _messageObjScript.RepliedMessageContent.text = _replied;
            }

            else
            {
                _messageObj = Instantiate(_outgoingMessageNR, transform);
                NoReplyMessage _messageObjScript = _messageObj.GetComponent<NoReplyMessage>();

                _messageObjScript.Username.text = _name;
                _messageObjScript.Initials.text = _initials;
                _messageObjScript.MessageContent.text = _content;
            }
        }


    }
}
