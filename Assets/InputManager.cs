using InputMangerAction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputMangerAction
{
    public class InputManagerAction
    {
        public Func<string, bool> TheFunc { get; set; }
        public string Trigger { get; set; }

        public InputManagerAction(Func<string, bool> myfunc, string trigger)
        {
            TheFunc = myfunc;
            Trigger = trigger;
        }

    }
}

public class InputManager : MonoBehaviour
{
    [SerializeField] private string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890"; // TODO maybe use something else
    [SerializeField] private string getUp;
    [SerializeField] private string getDown;
    [SerializeField] private List<string> isPressed;

    [SerializeField] public List<InputManagerAction> getDownFunctions = new List<InputManagerAction>();


    public string GetKeyDown
    {
        get { return getDown; }
    }

    public string GetKeyUp
    {
        get { return getUp; }
    }

    public List<string> GetKeyPressed
    {
        get { return isPressed; }
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (Input.GetKeyDown(Char.ToString(alphabet[i])))
            {
                string theChar = Char.ToString(alphabet[i]).ToUpper();
                getDown = theChar;
                isPressed.Add(theChar);
                int idx = getDownFunctions.FindIndex(getDownFunction => getDownFunction.Trigger == theChar);
                if (idx > -1)
                {
                    getDownFunctions[idx].TheFunc("potato");
                }
            }
            else
            {
                getDown = null;
            }
            if (Input.GetKeyUp(Char.ToString(alphabet[i])))
            {
                string theCar = Char.ToString(alphabet[i]).ToUpper();
                getUp = theCar;
                isPressed.Remove(theCar);
            }
            else
            {
                getUp = null;
            }
        }
    }
}