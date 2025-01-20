using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI timer;

    public TextMeshProUGUI powerName;
    public TextMeshProUGUI powerUpTitle;

    public Image powerBar;
    public GameObject pannel_HUD, pannel_PowerUp;

    private void Awake()
    {
        instance = this;
    }
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

    public void ShowHUD()
    {
        Time.timeScale = 1f;
        pannel_HUD.SetActive(true);
        pannel_PowerUp.SetActive(false);
    }

    public void ShowPowerUp(PowerUpList name)
    {
        Time.timeScale = 0f;
        powerUpTitle.text = name.ToString();
        pannel_HUD.SetActive(false);
        pannel_PowerUp.SetActive(true);
    }
}

