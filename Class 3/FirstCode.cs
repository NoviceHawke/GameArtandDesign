using UnityEngine;

public class FirstCode : MonoBehaviour
{
//Declareing Variables
    private int myInt = 42;
    [SerializeField] private float myFloat;
    private bool myBool = false;
    private string myString = "Hello World";
    private Vector2 myVector2 = new Vector2(1, 1);
    private Vector3 myVector3 = new Vector3(1, 1, 1);
    private string[] myList;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //printing your frist string and setting an array
        print(myString);
        myList = new string[5];
        myList[0] = "one";

    }

    // Update is called once per frame
    void Update()
    {
    //creating an input, you may need to switch your imput to use Both old and new under your  player project settings if this code does not work
        if (Input.GetKey(KeyCode.Q))
        {
            Adding();

        }
    }
//creating our own Funtion
    private void Adding()
    {
        myFloat++;
        print(myFloat);
    }
}




