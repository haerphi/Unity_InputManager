using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMangerAction;


public class Example : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private int compteur;
    [SerializeField] private string triggerOn;
    // Start is called before the first frame update
    void Start()
    {
        inputManager.AddFunctionOnKeyDown(new InputAction(ActionOnF, triggerOn));
    }

    public bool ActionOnF(string test)
    {
        compteur++;
        return true;
    }
}
