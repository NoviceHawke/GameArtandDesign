using UnityEngine;

public class Player_Health : MonoBehaviour
{
    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(float _hurt)
    {
        GameManager.instance.DamagePlayer(_hurt);

        if (GameManager.instance.currentPlayerLife > 0)
        {
            _animator.SetTrigger("ohHit");
        }
        else
        {
            //Triggering Death animation;
            print("dead");
        }
    }


      
}
