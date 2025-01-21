using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        PlayerPrefs.SetInt("Level1Status", (int)LevelStatus.unlocked);

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public LevelStatus GetLevelStatus(int levelIndex)
    {
        string level = $"Level{levelIndex}Status";
        return (LevelStatus)PlayerPrefs.GetInt(level, 0);
    }

    public void LoadLevel(int level)
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        if (level < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

}
