using UnityEngine;

public class DangerDetector : MonoBehaviour
{
    public float knockbackForce = 10f; 
    public float knockbackDuration = 3f; 
    private PlayerController playerController;
    

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("danger"))
        {
            // Turn off the player controller 
            playerController.enabled = false;
            Invoke("EnablePlayerController", knockbackDuration);

            // Calculate the knockback direction
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(knockbackDirection.x * knockbackForce, knockbackDirection.y * knockbackForce);
        }
    }

    private void EnablePlayerController()
    {
        playerController.enabled = true;
    }
}