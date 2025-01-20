using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI timer;

    public TextMeshProUGUI powerName;

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
}
