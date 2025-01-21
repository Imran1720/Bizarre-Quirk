using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    [Header("Timer Info")]
    public float maxTimer;
    float timer;
    [Header("Speed Info")]
    public float speedsterSpeed;
    public GameObject boostFX;


    int randomPowerUp;

    public PlayerController playerController;
    public Shrink shrinkScript;
    public BouncyBall bouncyBallScript;
    public GhostMovement ghostMovement;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        timer = maxTimer;
        UIManager.instance.UpdatePowerName(GetPowerName(PowerUpList.normal));
        ResetPowerUps();
        randomPowerUp = GetRandomPowerUp();

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        UIManager.instance.RefreshPowerBar(timer / maxTimer);
        if (timer <= 0)
        {
            ChangePowerUp();

            timer = maxTimer;
        }
    }

    public void ChangePowerUp()
    {
        ResetPowerUps();
        randomPowerUp = GetRandomPowerUp();
        UIManager.instance.ShowPowerUp((PowerUpList)randomPowerUp);
        UIManager.instance.UpdatePowerName(GetPowerName((PowerUpList)randomPowerUp));
        switch ((PowerUpList)randomPowerUp)
        {
            case PowerUpList.Antman:
                shrinkScript.enabled = true;
                break;
            case PowerUpList.Flash:
                PlayerController.instance.ActivateSpeedBoost(speedsterSpeed);
                boostFX.SetActive(true);
                break;
            case PowerUpList.Ghost:
                ghostMovement.enabled = true;
                playerController.enabled = false;
                break;
            case PowerUpList.Contrary_Will:
                PlayerController.instance.ReverseControls();
                break;
            case PowerUpList.Jumpstream:
                boostFX.SetActive(true);
                bouncyBallScript.enabled = true;
                break;
            case PowerUpList.normal:
                ResetPowerUps();
                break;
        }
    }

    public void ResetPowerUps()
    {
        if (playerController.enabled == false)
        {
            playerController.enabled = true;
        }
        PlayerController.instance.jumpCount = PlayerController.instance.maxJumpCount;
        PlayerController.instance.ResetSpeed();
        PlayerController.instance.ResetControls();
        bouncyBallScript.enabled = false;
        shrinkScript.enabled = false;
        ghostMovement.enabled = false;
        boostFX.SetActive(false);
    }

    public int GetRandomPowerUp()
    {
        return UnityEngine.Random.Range(0, Enum.GetNames(typeof(PowerUpList)).Length);
    }

    public string GetPowerName(PowerUpList power)
    {
        switch (power)
        {
            case PowerUpList.Ghost:
                return "You are a Ghost!!";

            case PowerUpList.Antman:
                return "You are an ant!!";
            case PowerUpList.Flash:
                return "You became Flash!!";
            case PowerUpList.Contrary_Will:
                return "You are Drunk!!";
            case PowerUpList.Jumpstream:
                return "You can't stop Jumping!!";
            case PowerUpList.normal:
                return "you are now normal!!";
        }
        return "normal";
    }
    public PowerUpList GetActivePower()
    {
        return (PowerUpList)randomPowerUp;
    }

}
