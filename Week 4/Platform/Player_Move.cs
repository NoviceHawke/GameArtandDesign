using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private float moveInput;
    private BoxCollider2D bCollider2D;
    private Rigidbody2D rB2D;
    private bool rightDirection;
    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] private LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        bCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if(moveInput > 0 && rightDirection)
        {
            Flip();

        }

        else if (moveInput < 0 && !rightDirection)
        {
            Flip();

        }

        if((Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.W))&& IsGrounded())
        {

            Jump();
        }
    }

    private void FixedUpdate()
    {
        rB2D.linearVelocityX = moveInput * speed;
    }

    private void Flip()
    {
        rightDirection = !rightDirection;
        transform.Rotate(0, 180, 0);
    }

    private void Jump()
    {
        rB2D.linearVelocityY = height;

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            bCollider2D.bounds.center,//The center point of our box collider
            bCollider2D.bounds.size,//the size of the box collider
            0, //no Angle needed
            Vector2.down,//the direction under our player
            0.1f,//distence
            groundLayer);//The layer we use for our ground

        return raycastHit.collider != null;


    }

}
