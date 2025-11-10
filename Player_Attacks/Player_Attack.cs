using Unity.VisualScripting;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public float range;
    public int damage;

    private float attackTime;
    private float numAttacks = 3;

    // Update is called once per frame
    void Update()
    {
        if (attackTime < Time.time)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Attack();
                attackTime = Time.time+(1f/numAttacks);
            }
        }
    }

    public void Attack()
    {
        
        animator.SetBool("attack", true);
        animator.SetTrigger("attackStart");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);

        foreach (Collider2D col in hit) {
        col.GetComponent<Enemy_Health>().DoDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }

    public void EndAttack()
    {
        animator.SetBool("attack", false);
    }
}
