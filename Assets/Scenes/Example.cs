using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMangerAction;


public class Example : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        inputManager.getDownFunctions.Add(new InputManagerAction(ActionOnF, "F"));
    }

    public bool ActionOnF(string test)
    {
        Debug.Log("actionOnF");

        return true;
    }
}
