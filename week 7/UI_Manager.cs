using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text scoreBox;
    public Image fullHealth;
    public Image currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreBox.text=GameManager.instance.score.ToString();
        currentHealth.fillAmount = GameManager.instance.currentPlayerLife / 10;
    }
}
