using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_DeathScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Reload()
    {
        GameManager.instance.Reset();
        SceneManager.LoadScene(1);
    }

    public void Leave()
    {
        //Application.Quit();
        // this code closes the app but only works in standalone play
        GameManager.instance.Reset();
        SceneManager.LoadScene(0);

    }
}
