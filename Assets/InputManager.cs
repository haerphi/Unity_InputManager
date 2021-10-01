using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputMangerAction
{
    public class InputAction
    {
        public Func<string, bool> TheFunc { get; set; }
        public string Trigger { get; set; }
        public int Priority { get; set; }

        public InputAction(Func<string, bool> myfunc, string trigger, int priority = 0)
        {
            TheFunc = myfunc;
            Trigger = trigger;
            Priority = priority;
        }
    }

    public class InputManager : MonoBehaviour
    {
        private readonly string alphabet = "abcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+[]{};':\",./<>?\\"; // TODO maybe use something else
        private string getUp;
        private string getDown;
        private List<string> isPressed = new List<string>();

        private List<InputAction> getKeyDownFunctions = new List<InputAction>();

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

        public bool AddFunctionOnKeyDown(InputAction action)
        {
            int idx = getKeyDownFunctions.FindIndex(getDownFunction => getDownFunction.Trigger == action.Trigger);
            // if the item exist and his priority is different of -1 or his priority is heighter than the new action
            if (idx > -1 && (getKeyDownFunctions[idx].Priority == -1 || getKeyDownFunctions[idx].Priority > action.Priority))
            {
                return false;
            }
            // if the item exist and his priority is lower than the new action 
            else if (idx > -1 && getKeyDownFunctions[idx].Priority <= action.Priority)
            {
                getKeyDownFunctions.Remove(getKeyDownFunctions[idx]);
            }

            getKeyDownFunctions.Add(action);
            return true;
        }

        public bool RemoveFunctionOnKeyDown(string trigger)
        {
            int idx = getKeyDownFunctions.FindIndex(getDownFunction => getDownFunction.Trigger == trigger);
            if (idx > -1)
            {
                getKeyDownFunctions.Remove(getKeyDownFunctions[idx]);
                return true;
            }

            return false;
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
                    int idx = getKeyDownFunctions.FindIndex(getDownFunction => getDownFunction.Trigger == theChar);
                    if (idx > -1)
                    {
                        getKeyDownFunctions[idx].TheFunc("potato");
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
}