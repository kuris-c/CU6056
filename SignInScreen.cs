using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SignInScreen : MonoBehaviour
{
    [Header("User Input Fields")]
    [SerializeField, Tooltip("Use Parent Object")] private TMP_InputField _enterHost;
    [SerializeField, Tooltip("Use Parent Object")] private TMP_InputField _enterPort;
    [SerializeField, Tooltip("Use Parent Object")] private TMP_InputField _enterName;

    [Header("User Buttons")]
    [SerializeField, Tooltip("Use Parent Object")] private Button _joinServer;
    [SerializeField, Tooltip("Use Parent Object")] private Button _makeServer;

    private void Start()
    {
        // ADD LISTENERS IF //
        _enterHost.onSelect.AddListener(HostSelected);
        _enterPort.onSelect.AddListener(PortSelected);
        _enterName.onSelect.AddListener(NameSelected);

        _enterHost.onDeselect.AddListener(HostSelected);
        _enterPort.onDeselect.AddListener(PortSelected);
        _enterName.onDeselect.AddListener(NameSelected);

        _enterHost.onSubmit.AddListener(HostSubmitted);
        _enterPort.onSubmit.AddListener(PortSubmitted);
        _enterName.onSubmit.AddListener(NameSubmitted);

        // ADD LISTENERS BT //
        _joinServer.onClick.AddListener(JoinServer);
        _makeServer.onClick.AddListener(MakeServer);
    }

    private void HostSelected(string msg)
    {
        // Invert Placeholder Text
        _enterHost.placeholder.GetComponent<TextMeshProUGUI>().text = _enterHost.gameObject == EventSystem.current.currentSelectedGameObject ? "" : "Enter IP Address...";

        // Check If Has Value
        if (_enterHost.text != "")
        {
            HostSubmitted(msg);
        }
    }

    private void PortSelected(string msg)
    {
        // Invert Placeholder Text
        _enterPort.placeholder.GetComponent<TextMeshProUGUI>().text = _enterPort.gameObject == EventSystem.current.currentSelectedGameObject ? "" : "Enter Port Address...";

        // Check If Has Value
        if (_enterPort.text != "")
        {
            PortSubmitted(msg);
        }
    }

    private void NameSelected(string msg)
    {
        // Invert Placeholder Text
        _enterName.placeholder.GetComponent<TextMeshProUGUI>().text = _enterName.gameObject == EventSystem.current.currentSelectedGameObject ? "" : "Enter Name...";

        // Check If Has Value
        if (_enterName.text != "")
        {
            NameSubmitted(msg);
        }
    }

    private void HostSubmitted(string msg)
    {
        // FADE OUT INPUT FIELD //
        _enterHost.GetComponent<Image>().enabled = false;
        _enterHost.caretColor = Color.white;
        _enterHost.textComponent.alignment = TextAlignmentOptions.Center;

        // SELECT NEXT INPUT FIELD //
        _enterPort.Select();
        _enterPort.ActivateInputField();

        // SET GLOBAL VARIABLE //
        Globals.Host = _enterHost.text;
    }

    private void PortSubmitted(string msg)
    {
        // FADE OUT INPUT FIELD //
        _enterPort.GetComponent<Image>().enabled = false;
        _enterPort.caretColor = Color.white;
        _enterPort.textComponent.alignment = TextAlignmentOptions.Center;

        // SELECT NEXT INPUT FIELD //
        _enterName.Select();
        _enterName.ActivateInputField();

        // SET GLOBAL VARIABLE //
        Globals.Port = _enterPort.text;
    }

    private void NameSubmitted(string msg)
    {
        // FADE OUT INPUT FIELD //
        _enterName.GetComponent<Image>().enabled = false;
        _enterName.caretColor = Color.white;
        _enterName.textComponent.alignment = TextAlignmentOptions.Center;

        // SET GLOBAL VARIABLE //
        Globals.Name = _enterName.text;
    }

    private void JoinServer()
    {
        if (Globals.Host != null && Globals.Port != null && Globals.Name != null)
        {
            TCPClient.Instance.JoinServer();
            UserInterfaceManager.Instance.OnSignInCompleted.Invoke();
        }
    }

    private void MakeServer()
    {
        if (Globals.Host != null && Globals.Port != null && Globals.Name != null)
        {
            TCPServer.Instance.MakeServer();
            UserInterfaceManager.Instance.OnSignInCompleted.Invoke();
        }
    }
}
