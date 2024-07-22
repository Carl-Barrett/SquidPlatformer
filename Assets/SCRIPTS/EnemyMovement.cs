using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float moveDistance = 5f;
    public LayerMask groundLayer;
    public float jumpInterval = 2f;
    public float directionChangeInterval = 3f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool movingRight = true;
    private float timeSinceLastJump = 0f;
    private float timeSinceLastDirectionChange = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        timeSinceLastJump += Time.deltaTime;
        timeSinceLastDirectionChange += Time.deltaTime;


        //jump
        if (timeSinceLastJump >= jumpInterval)
        {
            
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            timeSinceLastJump = 0f;
        }

        // Change direction
        if (timeSinceLastDirectionChange >= directionChangeInterval)
        {
            
            movingRight = !movingRight;
            timeSinceLastDirectionChange = 0f;
        }
    }

    private void FixedUpdate()
    {
        float moveDirection = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }
}


