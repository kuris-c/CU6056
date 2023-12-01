using UnityEngine;
using UnityEngine.UI;

public class TopBarManager : MonoBehaviour
{
    [Header("Theme Selection Menu")]
    [SerializeField] private GameObject _themeSelectionMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Theme Selection Menu Event
        TopBarButtons.ThemeSelectionMenuToggled += ShowThemeSelectionMenu;
        _themeSelectionMenu.GetComponent<Image>().enabled = false;
        _themeSelectionMenu.transform.GetChild(0).gameObject.SetActive(false);
        _themeSelectionMenu.transform.GetChild(1).gameObject.SetActive(false);
        _themeSelectionMenu.transform.GetChild(2).gameObject.SetActive(false);
        _themeSelectionMenu.transform.GetChild(3).gameObject.SetActive(false);
        _themeSelectionMenu.transform.GetChild(4).gameObject.SetActive(false);
        _themeSelectionMenu.transform.GetChild(5).gameObject.SetActive(false);
    }

    private void ShowThemeSelectionMenu()
    {
        _themeSelectionMenu.GetComponent<Image>().enabled = !_themeSelectionMenu.GetComponent<Image>().enabled;
        _themeSelectionMenu.transform.GetChild(0).gameObject.SetActive(!_themeSelectionMenu.transform.GetChild(0).gameObject.activeInHierarchy);
        _themeSelectionMenu.transform.GetChild(1).gameObject.SetActive(!_themeSelectionMenu.transform.GetChild(1).gameObject.activeInHierarchy);
        _themeSelectionMenu.transform.GetChild(2).gameObject.SetActive(!_themeSelectionMenu.transform.GetChild(2).gameObject.activeInHierarchy);
        _themeSelectionMenu.transform.GetChild(3).gameObject.SetActive(!_themeSelectionMenu.transform.GetChild(3).gameObject.activeInHierarchy);
        _themeSelectionMenu.transform.GetChild(4).gameObject.SetActive(!_themeSelectionMenu.transform.GetChild(4).gameObject.activeInHierarchy);
        _themeSelectionMenu.transform.GetChild(5).gameObject.SetActive(!_themeSelectionMenu.transform.GetChild(5).gameObject.activeInHierarchy);
    }
}
