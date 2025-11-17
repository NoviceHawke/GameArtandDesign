using UnityEngine;

public class Enemy_Arrow : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;

    public float lifeTime;
    private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // be sure your spawn point is on the "right" side of your enemey  at creation, this will ensure that when fliped you are fireing in the correct direction. 
        rb.linearVelocity = transform.right * speed;
    }


    private void Update()
    {
        //life time makes it so that the arrow will not fly forever
        currentTime = Time.deltaTime;  
        if (currentTime > lifeTime) { Destroy(gameObject); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stops the arrow from destorying if there is an overlap with the enemey sprite
        if (collision.tag != "Enemey")
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Player_health>().DamagePlayer(damage);
            }
            Destroy(gameObject);
        }
    }
}

