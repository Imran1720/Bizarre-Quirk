using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null && PowerUpManager.instance.GetActivePower() != PowerUpList.Ghost)
        {
            PlayerController.instance.DecreasePlayerHealth();
            PlayerController.instance.Respawn();
        }
    }
}
