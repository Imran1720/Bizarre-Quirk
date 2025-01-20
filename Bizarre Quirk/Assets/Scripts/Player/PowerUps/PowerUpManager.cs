using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Timer Info")]
    public float maxTimer;
    float timer;
    [Header("Speed Info")]
    public float speedsterSpeed;



    int randomPowerUp;

    public Shrink shrinkScript;
    public BouncyBall bouncyBallScript;

    private void Start()
    {
        randomPowerUp = GetRandomPowerUp();

    }

    private void Update()
    {
        timer -= Time.deltaTime;
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
        switch (randomPowerUp)
        {
            case 0:
                shrinkScript.enabled = true;
                break;
            case 1:
                PlayerController.instance.ActivateSpeedBoost(speedsterSpeed);
                break;
            case 2:
                Debug.Log("Enemies are Exploding");
                break;
            case 3:
                PlayerController.instance.ReverseControls();
                break;
            case 4:
                bouncyBallScript.enabled = true;
                break;
        }
    }

    public void ResetPowerUps()
    {
        shrinkScript.enabled = false;
        PlayerController.instance.ResetSpeed();
        PlayerController.instance.ResetControls();
        bouncyBallScript.enabled = false;
    }

    public int GetRandomPowerUp()
    {
        return UnityEngine.Random.Range(0, Enum.GetNames(typeof(PowerUpList)).Length);
    }

    public string GetPowerName(PowerUpList power)
    {
        switch (power)
        {
            case PowerUpList.ExplosiveEnemies:
                return "exploding enemies";

            case PowerUpList.Shirnk:
                return "Antman";
            case PowerUpList.SpeedSter:
                return "Flash";
            case PowerUpList.ReverseControl:
                return "Contrary Will";
            case PowerUpList.BouncyBall:
                return "Jumpstream";
        }
        return null;
    }
}
