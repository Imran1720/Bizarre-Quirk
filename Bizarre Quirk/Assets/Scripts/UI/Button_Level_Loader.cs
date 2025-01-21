using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Button_Level_Loader : MonoBehaviour
{

    public Levels level;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {

        LevelManager.instance.LoadLevel((int)level);

    }
}

public enum Levels
{
    Menu,
    Level1,
    Level2,
}
