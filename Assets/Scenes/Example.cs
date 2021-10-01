using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMangerAction;


public class Example : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private int compteur;
    // Start is called before the first frame update
    void Start()
    {
        inputManager.AddFunctionOnKeyDown(new InputAction(ActionOnF, "F"));
    }

    public bool ActionOnF(string test)
    {
        Debug.Log("actionOnF");
        compteur++;
        return true;
    }
}
