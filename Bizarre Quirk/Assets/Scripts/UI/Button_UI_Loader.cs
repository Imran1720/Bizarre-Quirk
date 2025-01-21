using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Button_UI_Loader : MonoBehaviour
{
    public Panel panel;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenPanel);
    }

    void OpenPanel()
    {
        if (panel == Panel.HUD)
        {
            UIManager.instance.Resume();
        }
        else
        {
            UIManager.instance.Pause();
        }
    }
}

public enum Panel
{
    HUD,
    PAUSE
}