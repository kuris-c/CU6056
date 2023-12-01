using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _whiteBtn;
    [SerializeField] private Button _blackBtn;
    [SerializeField] private Button _greyBtn;
    [SerializeField] private Button _purpleRainBtn;
    [SerializeField] private Button _orangeFlushBtn;
    [SerializeField] private Button _jollyBtn;

    [Header("Images To Update")]
    [SerializeField] private Image _openMenuButton;
    [SerializeField] private Image _themeSelectionMenuButton;
    [SerializeField] private GameObject _closeAppButton;
    [SerializeField] private Image _topBarBackground;
    [SerializeField] private Image _chatAppBackground;
    [SerializeField] private Image _bottomBarBackground;

    [Header("Open Menu Button Images")]
    [SerializeField] private Sprite _openMenuWhite;
    [SerializeField] private Sprite _openMenuBlack;

    [Header("Theme Selection Menu Button Images")]
    [SerializeField] private Sprite _themeSelectionMenuWhite;
    [SerializeField] private Sprite _themeSelectionMenuBlack;
    [SerializeField] private Sprite _themeSelectionMenuGrey;
    [SerializeField] private Sprite _themeSelectionMenuPurpleRain;
    [SerializeField] private Sprite _themeSelectionMenuOrangeFlush;
    [SerializeField] private Sprite _themeSelectionMenuJolly;

    [Header("Top Bar Background Images")]
    [SerializeField] private Sprite _topBarWhite;
    [SerializeField] private Sprite _topBarBlack;
    [SerializeField] private Sprite _topBarGrey;
    [SerializeField] private Sprite _topBarPurpleRain;
    [SerializeField] private Sprite _topBarOrangeFlush;
    [SerializeField] private Sprite _topBarJolly;

    [Header("Chat App Background Images")]
    [SerializeField] private Sprite _chatAppWhite;
    [SerializeField] private Sprite _chatAppBlack;
    [SerializeField] private Sprite _chatAppGrey;
    [SerializeField] private Sprite _chatAppPurpleRain;
    [SerializeField] private Sprite _chatAppOrangeFlush;
    [SerializeField] private Sprite _chatAppJolly;

    [Header("Bottom Bar Background Images")]
    [SerializeField] private Sprite _bottomBarWhite;
    [SerializeField] private Sprite _bottomBarBlack;
    [SerializeField] private Sprite _bottomBarGrey;
    [SerializeField] private Sprite _bottomBarPurpleRain;
    [SerializeField] private Sprite _bottomBarOrangeFlush;
    [SerializeField] private Sprite _bottomBarJolly;

    public bool LightMode;

    void Start()
    {
        // Add Listeners
        _whiteBtn.onClick.AddListener(() => ThemeChanged(_whiteBtn.name));
        _blackBtn.onClick.AddListener(() => ThemeChanged(_blackBtn.name));
        _greyBtn.onClick.AddListener(() => ThemeChanged(_greyBtn.name));
        _purpleRainBtn.onClick.AddListener(() => ThemeChanged(_purpleRainBtn.name));
        _orangeFlushBtn.onClick.AddListener(() => ThemeChanged(_orangeFlushBtn.name));
        _jollyBtn.onClick.AddListener(() => ThemeChanged(_jollyBtn.name));
    }

    private void ThemeChanged(string buttonName)
    {
        switch (buttonName)
        {
            case "White":
                LightMode = true;
                _openMenuButton.sprite = _openMenuBlack;
                _themeSelectionMenuButton.sprite = _themeSelectionMenuWhite;
                _closeAppButton.GetComponent<Image>().color = Color.black;
                _closeAppButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
                _topBarBackground.sprite = _topBarWhite;
                _chatAppBackground.sprite = _chatAppWhite;
                _bottomBarBackground.sprite = _bottomBarWhite;
                break;

            case "Black":
                LightMode = false;
                _openMenuButton.sprite = _openMenuWhite;
                _themeSelectionMenuButton.sprite = _themeSelectionMenuBlack;
                _closeAppButton.GetComponent<Image>().color = Color.white;
                _closeAppButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
                _topBarBackground.sprite = _topBarBlack;
                _chatAppBackground.sprite = _chatAppBlack;
                _bottomBarBackground.sprite = _bottomBarBlack;
                break;

            case "Grey":
                LightMode = false;
                _openMenuButton.sprite = _openMenuWhite;
                _themeSelectionMenuButton.sprite = _themeSelectionMenuGrey;
                _closeAppButton.GetComponent<Image>().color = Color.white;
                _closeAppButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
                _topBarBackground.sprite = _topBarGrey;
                _chatAppBackground.sprite = _chatAppGrey;
                _bottomBarBackground.sprite = _bottomBarGrey;
                break;

            case "Purple Rain":
                LightMode = false;
                _openMenuButton.sprite = _openMenuWhite;
                _themeSelectionMenuButton.sprite = _themeSelectionMenuPurpleRain;
                _closeAppButton.GetComponent<Image>().color = Color.white;
                _closeAppButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
                _topBarBackground.sprite = _topBarPurpleRain;
                _chatAppBackground.sprite = _chatAppPurpleRain;
                _bottomBarBackground.sprite = _bottomBarPurpleRain;
                break;

            case "Orange Flush":
                LightMode = false;
                _openMenuButton.sprite = _openMenuWhite;
                _themeSelectionMenuButton.sprite = _themeSelectionMenuOrangeFlush;
                _closeAppButton.GetComponent<Image>().color = Color.white;
                _closeAppButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
                _topBarBackground.sprite = _topBarOrangeFlush;
                _chatAppBackground.sprite = _chatAppOrangeFlush;
                _bottomBarBackground.sprite = _bottomBarOrangeFlush;
                break;

            case "Jolly":
                LightMode = false;
                _openMenuButton.sprite = _openMenuWhite;
                _themeSelectionMenuButton.sprite = _themeSelectionMenuJolly;
                _closeAppButton.GetComponent<Image>().color = Color.white;
                _closeAppButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
                _topBarBackground.sprite = _topBarJolly;
                _chatAppBackground.sprite = _chatAppJolly;
                _bottomBarBackground.sprite = _bottomBarJolly;
                break;
        }
    }
}
