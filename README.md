# Unity_InputManager ⌨

Remake Input Manager for Unity

## How to use it ?

- Add the script `InputManager` to any object (Like a singleton system, camera or stuff like that)
- `SerializeField` a variable in the script you need the InputManager
- Put the object that own `InputManager` script in this `SerializedField`
- Implement a function that the `InputManager` will call
- use the namespace `InputMangerAction`: `using InputMangerAction;`
- add event in functions list at the start of your script:

  ```C#
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
  ```
