using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Essentials")]
    public int maxkeys;
    public int keys;

    [Header("Essentials")]
    public int levelDuration;
    float timer;

    public Transform checkPoint;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        timer = levelDuration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        UIManager.instance.UpdateTimer((int)timer);
        if (timer <= 0)
        {
            UIManager.instance.GameOver();
        }
    }

    public void IncreaseKeyCount()
    {
        keys++;
        UIManager.instance.RefreshKeys(keys, maxkeys);
    }

    public void OpenDoor()
    {
        if (keys == maxkeys)
        {
            SoundManager.instance.PlaySFX(Sounds.GameComplete);
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            if (levelIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                levelIndex += 1;
                PlayerPrefs.SetInt($"Level{levelIndex}Status", (int)LevelStatus.unlocked);
            }
            UIManager.instance.LevelComplete();

        }

    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
    }

}
