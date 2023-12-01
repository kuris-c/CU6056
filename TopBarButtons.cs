using System;
using UnityEngine;
using UnityEngine.UI;

public class TopBarButtons : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _openMenuBtn;
    [SerializeField] private GameObject _changeTheme;
    private Button _changeThemeBtn;
    [SerializeField] private GameObject _closeApp;
    private Button _closeAppBtn;

    // Menu Background
    private Image _background;

    // Action
    public static Action ThemeSelectionMenuToggled;

    // Change Theme Menu Toggled
    private bool _themeSelectionMenuToggled = false;

    private void Start()
    {
        // Assign Background
        _background = transform.GetChild(0).GetComponent<Image>();

        // Assign Buttons
        _changeThemeBtn = _changeTheme.GetComponent<Button>();
        _closeAppBtn = _closeApp.GetComponent<Button>();

        // Add Listeners
        _openMenuBtn.onClick.AddListener(MenuToggled);
        _changeThemeBtn.onClick.AddListener(ChangeThemeToggled);
        _closeAppBtn.onClick.AddListener(CloseAppToggled);

        // Disable Menu
        _background.gameObject.SetActive(false);
        _changeTheme.SetActive(false);
        _closeApp.SetActive(false);
    }

    private void MenuToggled()
    {
        _background.gameObject.SetActive(!_background.gameObject.activeSelf);
        _changeTheme.SetActive(!_changeTheme.activeSelf);
        _closeApp.SetActive(!_closeApp.activeSelf);

        if (_themeSelectionMenuToggled)
        {
            ThemeSelectionMenuToggled?.Invoke();
        }
    }

    private void ChangeThemeToggled()
    {
        ThemeSelectionMenuToggled?.Invoke();
        _themeSelectionMenuToggled = !_themeSelectionMenuToggled;
    }

    private void CloseAppToggled()
    {
        Application.Quit();
    }
}
