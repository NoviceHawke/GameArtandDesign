using UnityEngine;

public class Add_Life : MonoBehaviour
{
    public float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.GiveLife(health);
            Destroy(gameObject);

        }
    }
}
