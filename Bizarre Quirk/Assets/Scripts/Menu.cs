using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button play_Button, back_Button, quit_Button;
    public GameObject homeScreen, levelScreen;
    // Start is called before the first frame update
    void Start()
    {
        play_Button.onClick.AddListener(OpenLevelScreen);
        back_Button.onClick.AddListener(OpenHomeScreen);
        quit_Button.onClick.AddListener(Quit);
    }

    void OpenLevelScreen()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        homeScreen.SetActive(false);
        levelScreen.SetActive(true);
    }

    void OpenHomeScreen()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        homeScreen.SetActive(true);
        levelScreen.SetActive(false);
    }

    void Quit()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        Application.Quit();
    }
}
