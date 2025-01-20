using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    public static CamerMovement instance;
    public Transform[] positions;
    private void Awake()
    {
        instance = this;
    }
    public void MoveTo(int target)
    {
        transform.position = new Vector3(positions[target].position.x, positions[target].position.y, transform.position.z);
    }
}
