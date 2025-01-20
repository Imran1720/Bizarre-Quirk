using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI timer;

    public TextMeshProUGUI powerName;

    public Image powerBar;

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
}
