using System;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    [Header("User Interface Modules")]
    [SerializeField, Tooltip("Use The Parent Empties as The GameObject")] private GameObject _signInScreen;
    [SerializeField, Tooltip("Use The Parent Empties as The GameObject")] private GameObject _chatHistory;
    [SerializeField, Tooltip("Use The Parent Empties as The GameObject")] private GameObject _bottomBar;

    [Header("User Interface Instance")]
    public static UserInterfaceManager Instance;
    public Action OnSignInCompleted;

    private void Start()
    {
        // INIT INSTANCE //
        Instance = this;

        // INIT ACTION //
        OnSignInCompleted += OpenChatWindow;
        _chatHistory.SetActive(false);
        _bottomBar.SetActive(false);   
    }

    private void OpenChatWindow()
    {
        _signInScreen.SetActive(false);
        _chatHistory.SetActive(true);
        _bottomBar.SetActive(true);
    }
}
