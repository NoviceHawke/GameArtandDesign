using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{

  
    public TMP_Text scoreBox;
    public Image fullHealth;
    public Image currentHealth;

    
    public GameObject pauseScreen;
    public bool isPaused= false;

   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreBox.text=GameManager.instance.score.ToString();
        currentHealth.fillAmount = GameManager.instance.currentPlayerLife / 10;

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }

            else
            {
                PauseGame(true);
            }      
        }
    }

    private void PauseGame( bool _status)
    {
        pauseScreen.SetActive(_status);

        if (_status)
        {
            Time.timeScale = 0;
            GameManager.instance.isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            GameManager.instance.isPaused = false;
        }

    }
}
