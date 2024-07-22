using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7f;
    public float moveSpeed = 4f;
    public float downwardAcceleration = 1f; // New variable for downward acceleration
    public CircleCollider2D groundCheck;
    public LayerMask groundLayer;
    public int maxJumps = 2;
    public Rigidbody2D rb;
    private bool isGrounded = false;
    private int jumpsRemaining = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
       
        isGrounded = Physics2D.IsTouchingLayers(groundCheck, groundLayer);

        
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
            
        }

        
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - downwardAcceleration);
        }
    }

    private void FixedUpdate()
    {
        
        float moveInput = Input.GetAxisRaw("Horizontal");

        
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
