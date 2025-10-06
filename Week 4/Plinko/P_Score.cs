using UnityEngine;

public class P_Score : MonoBehaviour
{
    [SerializeField] private int score;
  //  private BoxCollider2D trigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player over laps this box. it will print this code
        if(collision.tag == "Player")
        {

            print(score);
        }
    }


}
