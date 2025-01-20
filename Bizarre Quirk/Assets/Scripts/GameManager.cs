using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Essentials")]
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
    }

    public void IscreaseKeyCount()
    {
        keys++;
    }



}
