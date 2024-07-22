using UnityEngine;

public class DownForceDetector : MonoBehaviour
{
    public float downForceStrength = 10f; 
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("downward force"))
        {
            
            rb.AddForce(Vector2.down * downForceStrength, ForceMode2D.Force);
        }
    }
}
