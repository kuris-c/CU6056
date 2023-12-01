using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReplyMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI Username;
    public TextMeshProUGUI Initials;
    public TextMeshProUGUI MessageContent;
    public TextMeshProUGUI RepliedMessageContent;
    public Button ReplyButton;

    public void Awake()
    {
        // Init Variables
        Username = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Initials = transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        MessageContent = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        ReplyButton = transform.GetChild(4).GetComponent<Button>();
        RepliedMessageContent = transform.GetChild(5).GetComponent<TextMeshProUGUI>();

        // Add Listener To Button
        ReplyButton.onClick.AddListener(ReplyButtonsPressed);

        // Disable Button
        ReplyButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (FindAnyObjectByType<ThemeManager>().LightMode)
        {
            Username.color = Color.black;
            Initials.color = Color.black;
            Initials.gameObject.transform.parent.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.black;
            MessageContent.color = Color.black;
            RepliedMessageContent.color = Color.black;
        }

        else
        {
            Username.color = Color.white;
            Initials.color = Color.white;
            Initials.gameObject.transform.parent.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
            MessageContent.color = Color.white;
            RepliedMessageContent.color = Color.white;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ReplyButton.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ReplyButton.gameObject.SetActive(false);
    }

    private void ReplyButtonsPressed()
    {
        // Invert Text To Signify If Replying Or Not
        InvertText();

        // Send Reply Text Content
        if (ReplyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "+")
        {
            FindAnyObjectByType<InputMessage>().IsReplyingToMessage(MessageContent.text, true);
        }

        else
        {
            FindAnyObjectByType<InputMessage>().IsReplyingToMessage(MessageContent.text, false);
        }

        // Ensure Input Field Is Selected
        FindAnyObjectByType<InputMessage>().InputField.Select();
        FindAnyObjectByType<InputMessage>().InputField.ActivateInputField();

        // Check All Other Reply Buttons And Invert Them
        foreach (var msg in Globals.MessageList)
        {
            if (msg.MessageObj != gameObject)
            {
                if (msg.MessageObj.GetComponent<ReplyMessage>() != null && msg.MessageObj.GetComponent<ReplyMessage>().ReplyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != ">")
                {
                    msg.MessageObj.GetComponent<ReplyMessage>().InvertText();
                }

                else if (msg.MessageObj.GetComponent<NoReplyMessage>() != null && msg.MessageObj.GetComponent<NoReplyMessage>().ReplyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != ">")
                {
                    msg.MessageObj.GetComponent<NoReplyMessage>().InvertText();
                }
            }
        }
    }

    public void InvertText()
    {
        if (ReplyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == ">")
        {
            ReplyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+";
        }

        else
        {
            ReplyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ">";
        }
    }
}
