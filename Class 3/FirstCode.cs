using UnityEngine;

public class FirstCode : MonoBehaviour
{
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
        print(myString);
        myList = new string[5];
        myList[0] = "one";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Adding();

        }
    }

    private void Adding()
    {
        myFloat++;
        print(myFloat);
    }
}



