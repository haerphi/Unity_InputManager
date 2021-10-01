# Unity_InputManager

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

  ```

## Usage

## InputAction class from

- getter setter `TheFunc`: `Func<string, bool>`, function that will be executed
- getter setter `Trigger`: `string`, key to trigger (actual: `abcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+[]{};':",./<>?`, coming soon: special key like ctrl or alt, space, etc)
- getter setter `Priority`: `int`, priority of the key (for example: if you set an action on "A" key with priority 99, and you try to override it with a lower priority, it won't change the action)
- constructor `InputAction(Func<string, bool> myfunc, string trigger, int priority = 0)`: `InputManagerAction`, create a InputManagerAction

### InputManager Script

- getter `GetKeyDown`: `string`, actual down input (on the frame)
- getter `GetKeyUp`: `string`, actual up input (on the frame)
- getter `GetKeyPressed`: `List<string>`, list of pressed input
- method `AddFunctionOnKeyDown(InputAction)`: `bool`, add a action on one key down
- method `RemoveFunctionOnKeyDown(string)`: `bool`, remove action with a certain trigger
