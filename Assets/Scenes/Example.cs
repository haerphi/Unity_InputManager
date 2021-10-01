using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMangerAction;


public class Example : MonoBehaviour
{
    [SerializeField] private GameObject inputManagerGameObject;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = inputManagerGameObject.GetComponent<InputManager>();
        InputManagerAction testOnF = new InputManagerAction(ActionOnF, "F");
        if (inputManager)
        {
            inputManager.getDownFunctions.Add(testOnF);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.GetKeyDown == "F")
        {
            Debug.Log("KEY F IS DOWN !!");
        }
    }

    public bool ActionOnF(string test)
    {
        Debug.Log("actionOnF");

        return true;
    }
}
