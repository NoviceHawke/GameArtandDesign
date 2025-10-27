using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float maxPlayerLife;
    public float currentPlayerLife;
    public bool isPaused;

    public GameObject[] coins;
 

        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].GetComponent<Add_Score>().points = Random.Range(1,10);
        
        } 
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
