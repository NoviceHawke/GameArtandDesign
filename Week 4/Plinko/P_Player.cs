using UnityEngine;

public class P_Player : MonoBehaviour
{
    private Rigidbody2D rB2D;
    private float moveInput;
    [SerializeField] private float speed;
    private bool rightDirection;
    private bool placement = true;
    private Vector2 startPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // finds and assigns the Rigidbody
        rB2D = GetComponent<Rigidbody2D>();
        rB2D.gravityScale = 0;

        // remembers the players starting point
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {// checks the input for A and D keys
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space)&& placement)
        {
            Balldrop();

        }

        if(Input.GetKey(KeyCode.Q)&& !placement)
        {
            ResetBall();
        }


    }

    private void FixedUpdate()
    {
        if (placement)
        {
            rB2D.linearVelocity = new Vector2(moveInput * speed, rB2D.linearVelocity.y);

        }
    }



    private void Balldrop()
    {
        placement = false;
        rB2D.gravityScale = 1;
    }

    private void ResetBall()
    {
        placement = true;
        rB2D.gravityScale = 0;
        // resets player Velocity
        rB2D.linearVelocity = new Vector2(0, 0);
        // returns player to starting point
        transform.position = startPoint;


    }

}
