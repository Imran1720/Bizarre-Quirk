using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("PANEL / SCREEN ")]
    public GameObject pannel_HUD;
    public GameObject pannel_PowerUp;
    public GameObject pannel_Pause;
    public GameObject pannel_GameOver;
    public GameObject pannel_GameComplete;



    [Header("UI-TEXTS")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI powerName;
    public TextMeshProUGUI powerUpTitle;


    [Header("UI-IMAGES")]
    public Image powerBar;
    public GameObject[] hearts;
    public GameObject[] keySlot;
    public Sprite keySprite;
    private void Awake()
    {
        instance = this;
    }

    //UI
    public void UpdateTimer(int time)
    {
        timer.text = time.ToString();
    }

    public void UpdatePowerName(string name)
    {
        powerName.text = name.ToUpper();
    }

    public void RefreshPowerBar(float value)
    {
        powerBar.fillAmount = value;

    }
    public void RefreshHealth(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i > health - 1)
            {
                hearts[i].SetActive(false);

            }
        }
    }

    public void RefreshKeys(int keys, int maxKeys)
    {
        for (int i = 0; i < maxKeys; i++)
        {
            if (i <= keys - 1)
            {
                keySlot[i].GetComponent<Image>().sprite = keySprite;

            }
        }
    }

    //PANELS
    public void Resume()
    {
        Time.timeScale = 1f;
        pannel_HUD.SetActive(true);
        pannel_Pause.SetActive(false);
        pannel_PowerUp.SetActive(false);
    }

    public void ShowPowerUp(PowerUpList name)
    {
        Time.timeScale = 0f;
        powerUpTitle.text = name.ToString();
        pannel_HUD.SetActive(false);
        pannel_PowerUp.SetActive(true);
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        pannel_Pause.SetActive(true);

    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        pannel_GameOver.SetActive(true);

    }

    public void LevelComplete()
    {
        Time.timeScale = 0f;
        pannel_GameComplete.SetActive(true);
    }

}

