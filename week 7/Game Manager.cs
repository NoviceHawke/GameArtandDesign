using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float maxPlayerLife;
    public float currentPlayerLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddScore(int _score)
    {
       score= score+_score;
        print(score);
    }

    public void GiveLife(float _health)
    {
        currentPlayerLife = Mathf.Clamp(currentPlayerLife + _health, 0, maxPlayerLife);
        print(currentPlayerLife);
    }

    public void DamagePlayer(float _damage)
    {

        currentPlayerLife = Mathf.Clamp(currentPlayerLife - _damage, 0, maxPlayerLife);
        print(currentPlayerLife);
    }

    public void Reset()
    {
        currentPlayerLife = maxPlayerLife;
        score = 0;
    }

}
