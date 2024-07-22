using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float collisionForce = 10f;
    public int maxHitCount = 5;
    public float loadDelay = 3f;
    public GameObject[] hitIndicators;
    public GameObject activateOnMaxHit;

    private int hitCount = 0;
    private bool isDead = false;
    private bool canCollide = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canCollide && collision.gameObject.CompareTag("Enemy"))
        {
            // direction of collision
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            // push player away from collision
            GetComponent<Rigidbody2D>().AddForce(-direction * collisionForce, ForceMode2D.Impulse);

            hitCount++;

            // Update lives
            for (int i = 0; i < hitIndicators.Length; i++)
            {
                if (i < hitCount)
                {
                    hitIndicators[i].SetActive(false);
                }
                else
                {
                    hitIndicators[i].SetActive(true);
                }
            }

            // Check if dead
            if (hitCount >= maxHitCount && !isDead)
            {
                isDead = true;

                // Disable player controller 
                PlayerController playerController = GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.enabled = false;
                }

                // Activate gameover screen
                if (activateOnMaxHit != null)
                {
                    activateOnMaxHit.SetActive(true);
                }

                // Load scene after delay
                Invoke("LoadScene", loadDelay);
            }
            else
            {
                
                canCollide = false;
                Invoke("EnableCollision", 1f);
            }
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Restart");
    }

    private void EnableCollision()
    {
        canCollide = true;
    }
}








