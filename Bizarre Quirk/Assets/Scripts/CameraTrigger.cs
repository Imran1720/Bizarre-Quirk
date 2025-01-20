using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public int targetIndex;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            GameManager.instance.checkPoint = this.transform;
            CamerMovement.instance.MoveTo(targetIndex);
        }
    }
}
