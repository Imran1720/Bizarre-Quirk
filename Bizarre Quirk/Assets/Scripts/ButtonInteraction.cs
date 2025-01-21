using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonInteraction : MonoBehaviour
{
    Button button;
    public int levelIndex;
    private void OnEnable()
    {

        button = GetComponent<Button>();
        string level = $"Level{levelIndex}Status";
        if (PlayerPrefs.GetInt(level, 0) != (int)LevelStatus.unlocked)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    private void Start()
    {
        button.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        LevelManager.instance.LoadLevel(levelIndex);
    }

}
