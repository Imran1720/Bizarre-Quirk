using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
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
        UIManager.instance.RefreshPowerBar(timer / 5);
        if (timer <= 0)
        {
            ChangePowerUp();
            Debug.ClearDeveloperConsole();
            Debug.Log((PowerUpList)randomPowerUp);
            timer = maxTimer;
        }
    }

    public void ChangePowerUp()
    {
        ResetPowerUps();
        randomPowerUp = GetRandomPowerUp();
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
            Debug.Log("Player movement activated");
            playerController.enabled = true;
        }
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
                return "You are a Ghost";

            case PowerUpList.Antman:
                return "Antman";
            case PowerUpList.Flash:
                return "Flash";
            case PowerUpList.Contrary_Will:
                return "Contrary Will";
            case PowerUpList.Jumpstream:
                return "Jumpstream";
            case PowerUpList.normal:
                return "normal";
        }
        return "normal";
    }
}
