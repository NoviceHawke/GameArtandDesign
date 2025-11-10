using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health;

    public void DoDamage(int _damage)
    {
        health = health - _damage;
        print(health);

        if( health <= 0)
        {
            Destroy(gameObject);
        }
    }
        
}
