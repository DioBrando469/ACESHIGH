using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject MainMenu;

    public void LoadSettingsMenu()
    {
        settingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
