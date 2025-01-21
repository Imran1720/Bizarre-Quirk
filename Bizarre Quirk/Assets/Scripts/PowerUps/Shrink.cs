using UnityEngine;

public class Shrink : MonoBehaviour
{
    [Header("Scale Info")]
    Vector2 defaultScale;
    public Vector2 shrinkScale;

    [Header("FlipVector Info")]
    public float flipVector_Shrinked;
    float flipVector_default;

    int facingDirection;
    float defaultJumpforce;

    private void Awake()
    {
        flipVector_default = PlayerController.instance.flipVector;
        defaultScale = PlayerController.instance.transform.localScale;
        defaultJumpforce = PlayerController.instance.jumpForce;
    }
    private void OnEnable()
    {
        facingDirection = PlayerController.instance.transform.localScale.x > 0 ? 1 : -1;
        shrinkScale.x = facingDirection * Mathf.Abs(shrinkScale.x);
        SetScale(shrinkScale, flipVector_Shrinked);

        SetJumpForce(defaultJumpforce - (defaultJumpforce / 4));

    }

    private void OnDisable()
    {
        facingDirection = PlayerController.instance.transform.localScale.x > 0 ? 1 : -1;
        defaultScale.x = facingDirection * Mathf.Abs(defaultScale.x);
        SetScale(defaultScale, flipVector_default);

        SetJumpForce(defaultJumpforce);
    }

    private void SetJumpForce(float force)
    {
        PlayerController.instance.jumpForce = force;
    }

    private void SetScale(Vector2 scale, float flipVector)
    {
        PlayerController.instance.flipVector = flipVector;
        PlayerController.instance.transform.localScale = scale;
    }
}
