using UnityEngine;
using UnityEngine.SceneManagement;
public class Ui_Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlay()
    {

        SceneManager.LoadScene(1);
    }
}
