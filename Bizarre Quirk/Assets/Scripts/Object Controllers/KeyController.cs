using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            SoundManager.instance.PlaySFX(Sounds.PickUp);
            GameManager.instance.IncreaseKeyCount();
            Destroy(gameObject);
        }
    }
}
