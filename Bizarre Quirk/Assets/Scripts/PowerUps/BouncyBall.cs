using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public PhysicsMaterial2D bouncyMaterial;
    public float force;

    public float maxTimer;
    float timer;
    //public PlayerController playerController;
    private void OnEnable()
    {
        PlayerController.instance.enabled = false;
        PlayerController.instance.rb.sharedMaterial = bouncyMaterial;
        PlayerController.instance.rb.AddForce(new Vector2(-1 * force, force), ForceMode2D.Impulse);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A) && timer <= 0)
        {
            timer = maxTimer;
            PlayerController.instance.rb.AddForce(new Vector2(-2 * force, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) && timer <= 0)
        {
            timer = maxTimer;
            PlayerController.instance.rb.AddForce(new Vector2(2 * force, 0), ForceMode2D.Impulse);
        }
    }
    private void OnDisable()
    {
        PlayerController.instance.rb.sharedMaterial = null;
        PlayerController.instance.enabled = true;

    }
}
