using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public Animator animator;

    public float speed;
    public int damage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2D.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidBody2D.linearVelocityX = 0;
        if( collision.tag== "Enemy")
        {
            collision.GetComponent<Enemy_Health>().DoDamage(damage);    
        }

        animator.SetTrigger("onHit");
    }


    public void KillBullet()
    {
        Destroy(gameObject);
    }
}
