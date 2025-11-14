using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{//Please Check the varirable List and Build your object BEFORE you add your script or the object or you will pass Errors
    // for this code you will need 2 Empty Game Objects, to act as the two patrol end points, Ridgbody 2D, collider2D

    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D rB;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    public bool idle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("IsRunning", true);
        idle = false;

}

    // Update is called once per frame
    void Update()
    {

        if (!idle)
        {
            if (anim.GetBool("IsRunning") == false)
            {
                anim.SetBool("IsRunning", true);
            }
            
            if (currentPoint == pointB.transform)
            {
                rB.linearVelocity = new Vector2(speed, 0);
            }
            else
            {
                rB.linearVelocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5 && currentPoint == pointB.transform)
            {
                Flip();
                currentPoint = pointA.transform;

                //if you want to have your enemey pause you can add a Coroutine here to pause the enemey in idle before continueing to move it.

            }


            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5 && currentPoint == pointA.transform)
            {
                Flip();
                currentPoint = pointB.transform;

            }
        }
        else
        {//sets the enemey to idle
            if (anim.GetBool("IsRunning") == true)
            {
                anim.SetBool("IsRunning", false);
            }

            rB.linearVelocity = new Vector2(0, 0);
        }
    }



    public void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    // allows us to see out points
   //allows us to see the enemey's path
   /* private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5F);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5F);
        Gizmos.DrawLine(pointA.transform.position,pointB.transform.position);
    }*/
}

