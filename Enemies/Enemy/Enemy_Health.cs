using UnityEngine;

public class Enemey_Health : MonoBehaviour
{
    public int health;
    public Animator animator;
    public Behaviour[] scripts;


    public void Damaged(int _attack)
    {
        health=health-_attack;
        print(health);
        GetComponent<Enemy_Patrol>().idle = true;
        //Triggers hurt animation can be replaced with a color changing Coroutine like we showed before
        animator.SetTrigger("hurt");

        if (health <= 0)
        {
           //disables all other scripts
            foreach(Behaviour b in scripts)
            {
                b.enabled = false;
            }
            //triggers death animation
            animator.SetTrigger("dead");
        }
    }

    public void AnimationDone()
    {
        //resets our animation
        animator.SetTrigger("return");
        GetComponent<Enemy_Patrol>().idle =false;
    }

    public void Dead()
    {
       animator.enabled = false;
        Destroy(gameObject);
    }
}
