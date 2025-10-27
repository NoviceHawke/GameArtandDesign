using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    private Animator _animator;

    [Header("Disable Damage Effect")]

    public float iframesTime;
    public float NumColorChange;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            StartCoroutine(NoDamage());
            StartCoroutine(Camera_Shake.instance.CamShake(3, 0.5f));
        }
        else
        {
            _animator.SetTrigger("death");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
        //you would change your number based on the number of levels and the load orader
    }
   
    private IEnumerator NoDamage()
    {
        Physics2D.IgnoreLayerCollision(3,7,true);
        // the 3 and 7 should be what ever your player and Damanage doing objects layers are,
        for (int i = 0; i < NumColorChange; i++) {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesTime / NumColorChange / 2);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iframesTime / NumColorChange / 2);
        }
        Physics2D.IgnoreLayerCollision(3, 7, false);
    }

}
