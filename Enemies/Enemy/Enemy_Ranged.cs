using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{
    Animator animator;

    public float sightLine;
    public float attackPause;
    public float waitTime;

    public Transform firePoint;
    public GameObject arrowPrefab;
    public LayerMask player;
    public bool attacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitTime = attackPause;
        animator = GetComponent<Animator>();
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //wait time is use to stop the enemey from fireing every frame, allows for a pause
        waitTime += Time.deltaTime;
        if (waitTime >= attackPause)
        {
            //if the player is in long attack range, but NOT in close attack range this will trigger the arrowed attack. 
            if (InSight()&& !GetComponent<Enemy_CloseAttack>().closeRange)
            {
                GetComponent<Enemy_Patrol>().idle = true;
                animator.SetTrigger("attack3");
                waitTime = 0;

            }
        }
        
    }

    //allows us to see where our RayCasted onbjects will be for Testing
   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (transform.localRotation.y > -.01) { Gizmos.DrawLine(transform.position, new Vector3((transform.position.x + sightLine), transform.position.y, transform.position.z)); }
       
        else { Gizmos.DrawLine(transform.position, new Vector3((transform.position.x - sightLine), transform.position.y, transform.position.z)); }
    }*/

  //checks if the player is within fire range
    public bool InSight()
    {//checks if the player is in range based on which direction you are faceing.
        if (transform.localRotation.y > -.01)
        {
            RaycastHit2D raycastHit = Physics2D.Linecast(transform.position, new Vector3((transform.position.x + sightLine), transform.position.y, transform.position.z),player);
            return raycastHit.collider != null;
        }

        else {
            RaycastHit2D raycastHit = Physics2D.Linecast(transform.position, new Vector3((transform.position.x -sightLine), transform.position.y, transform.position.z),player);
            return raycastHit.collider != null;
        }
    }

    //shoots bullet after animation
    public void Shoot()
    {
        Instantiate(arrowPrefab,firePoint.position, firePoint.rotation);    
        animator.SetTrigger("return");
        // can add a Coroutine here in plase of the insight check to keep the player idleing for a moment before checking if they are still in range
        if (!InSight())
        {
            GetComponent<Enemy_Patrol>().idle = false;
        }
        
    }
}
