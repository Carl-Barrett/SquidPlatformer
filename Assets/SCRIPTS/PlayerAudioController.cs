using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource groundHitSound;
    public AudioSource enemyHitSound;
    
    public PlayerController PlayerController;
    public void Start()
    {
        
        groundHitSound.playOnAwake = false;
        groundHitSound.loop = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground") && PlayerController.rb.velocity.y < 1f)
        {
            groundHitSound.Play();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHitSound.Play();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
        }
    }
}


