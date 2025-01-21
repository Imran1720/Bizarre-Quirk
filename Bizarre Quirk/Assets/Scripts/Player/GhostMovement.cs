using UnityEngine;
using UnityEngine.Tilemaps;

public class GhostMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator playerAnimator;
    public GameObject platform;

    float xInput;
    float yInput;
    public float speed;
    public GameObject timerUI;

    public GameObject tail;

    private void OnEnable()
    {

        rb = GetComponent<Rigidbody2D>();
        playerAnimator.SetBool("Grounded", false);
        rb.gravityScale = 0;
        platform.GetComponent<TilemapCollider2D>().isTrigger = true;
        tail.SetActive(true);
        tail.GetComponent<TrailRenderer>().startColor = Color.cyan;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);


    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        PlayerMovement();
        Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        if (xInput > 0)
        {
            localScale.x = 1;
        }
        if (xInput < 0)
        {
            localScale.x = -1;
        }
        transform.localScale = localScale;
        timerUI.transform.localScale = localScale;
    }

    public void PlayerMovement()
    {
        rb.velocity = new Vector2(xInput * speed, yInput * speed);
    }

    private void OnDisable()
    {
        playerAnimator.SetBool("Grounded", false);
        rb.gravityScale = 1;
        if (platform != null)
        {
            platform.GetComponent<TilemapCollider2D>().isTrigger = false;
        }
        tail.SetActive(false);
        tail.GetComponent<TrailRenderer>().startColor = Color.yellow;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

    }
}
