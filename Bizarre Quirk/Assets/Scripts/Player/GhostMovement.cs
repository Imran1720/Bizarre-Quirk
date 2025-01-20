using UnityEngine;
using UnityEngine.Tilemaps;

public class GhostMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject platform;

    float xInput;
    float yInput;
    public float speed;


    private void OnEnable()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        platform.GetComponent<TilemapCollider2D>().isTrigger = true;


    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        rb.velocity = new Vector2(xInput * speed, yInput * speed);
    }

    private void OnDisable()
    {
        rb.gravityScale = 1;
        platform.GetComponent<TilemapCollider2D>().isTrigger = false;
    }
}
