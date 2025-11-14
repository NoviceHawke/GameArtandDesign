using System.Collections;
using UnityEngine;

public class Enemy_CloseAttack : MonoBehaviour
{
    public float attackRange;
    public LayerMask player;
    bool canAttack;
    private Animator animator;
    private float cooldownTimer;
    public float attackTime;
    public Transform attackPoint;
    public int damage;
    public bool closeRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>(); 
       cooldownTimer= attackTime;
        closeRange = false;
    }

    // Update is called once per frame
    void Update()
    {
       //cool down stops the enemy from attacking too often 
        cooldownTimer += Time.deltaTime;
        if (inSights()){
         
            
            //randomly assigns one of two attacks. 
            if (cooldownTimer >= attackTime)
            {
                int r = Random.Range(0, 10);
                if (r > 5)
                {
                    animator.SetTrigger("Attackl1");
                    cooldownTimer = 0;
                }

                else
                {
                    animator.SetTrigger("Attack2");
                    cooldownTimer = 0;
                }


            }   
        }
    }

    //shows us the attack range for Debug
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/


   private bool inSights()
    {//checks if the player is within close range for a close attack. 
       Collider2D hit =Physics2D.OverlapCircle(attackPoint.position, attackRange,player);

        if (hit != null && hit.tag == "Player")
        {
            closeRange = true; 
            GetComponent<Enemy_Patrol>().idle = true;
            return true;

        }
        else if (!GetComponent<Enemy_Ranged>().InSight())
        {
            closeRange = false;
            GetComponent<Enemy_Patrol>().idle = false;



            return false;
        }
        else {
            closeRange = false;
            return false; }
    }

public void AttackDone() {
        //applys damage if the player is still within the attack's range
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, player);
        if(hit != null) {   
        
            hit.GetComponent<Player_health>().DamagePlayer(damage);
        }

        animator.SetTrigger("return");

    }

  
}
