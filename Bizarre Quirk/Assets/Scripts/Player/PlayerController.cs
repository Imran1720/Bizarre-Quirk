using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D rb;

    [Header("Player Movement info")]
    private float xInput;
    public MovementMode movementMode;
    public float speed;
    public float flipVector;

    [Header("Ground info")]
    public LayerMask whatIsGround;
    public Transform groundCheckPosition;
    public float groundCheckDistance;
    bool isGrounded;

    [Header("Jump info")]
    public float jumpForce;
    bool canDoubleJump = true;
    int jumpCount;
    public int maxJumpCount;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        PlayerMovement();
        Jump();
        Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        if (xInput > 0)
        {
            localScale.x = Mathf.Abs(flipVector);
        }
        else if (xInput < 0)
        {
            localScale.x = -1 * Mathf.Abs(flipVector);
        }
        transform.localScale = localScale;
    }

    private void PlayerMovement()
    {
        SetVelocity(speed * xInput, rb.velocity.y);
    }


    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }
    private void PlayerInput()
    {
        xInput = Input.GetAxisRaw("Horizontal") * (int)movementMode;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount--;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

    private bool GroundCheck()
    {
        return Physics2D.Raycast(groundCheckPosition.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheckPosition.transform.position, new Vector3(groundCheckPosition.position.x, groundCheckPosition.position.y - groundCheckDistance));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.CompareTag("Ground")) && GroundCheck())
        {
            isGrounded = true;
            canDoubleJump = true;
            jumpCount = maxJumpCount;
        }
    }
}
