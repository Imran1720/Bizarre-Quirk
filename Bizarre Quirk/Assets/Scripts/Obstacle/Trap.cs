using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            PlayerController.instance.DecreasePlayerHealth();
            PlayerController.instance.Respawn();
        }
    }
}
