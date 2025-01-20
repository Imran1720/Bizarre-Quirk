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
        timer = maxTimer;
        UIManager.instance.UpdatePowerName(GetPowerName(PowerUpList.normal));
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
            case PowerUpList.Shirnk:
                shrinkScript.enabled = true;
                break;
            case PowerUpList.SpeedSter:
                PlayerController.instance.ActivateSpeedBoost(speedsterSpeed);
                break;
            case PowerUpList.ExplosiveEnemies:
                Debug.Log("Enemies are Exploding");
                break;
            case PowerUpList.ReverseControl:
                PlayerController.instance.ReverseControls();
                break;
            case PowerUpList.BouncyBall:
                bouncyBallScript.enabled = true;
                break;
            case PowerUpList.normal:
                ResetPowerUps();
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
            case PowerUpList.normal:
                return "normal";
        }
        return "normal";
    }
}
