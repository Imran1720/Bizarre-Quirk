using UnityEngine;

public class Shrink : MonoBehaviour
{
    [Header("Scale Info")]
    Vector2 defaultScale;
    public Vector2 shrinkScale;
    public float flipVector_Shrinked;
    float flipVector_default;
    int facingDirection;

    private void Awake()
    {
        flipVector_default = PlayerController.instance.flipVector;
        defaultScale = PlayerController.instance.transform.localScale;
    }
    private void OnEnable()
    {
        facingDirection = PlayerController.instance.transform.localScale.x > 0 ? 1 : -1;
        shrinkScale.x = facingDirection * Mathf.Abs(shrinkScale.x);
        PlayerController.instance.transform.localScale = shrinkScale;
        PlayerController.instance.flipVector = flipVector_Shrinked;

    }

    private void OnDisable()
    {
        facingDirection = PlayerController.instance.transform.localScale.x > 0 ? 1 : -1;
        defaultScale.x = facingDirection * Mathf.Abs(defaultScale.x);
        PlayerController.instance.flipVector = flipVector_default;
        PlayerController.instance.transform.localScale = defaultScale;
    }
}
