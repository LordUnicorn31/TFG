using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Name: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Canvas cv;
    [SerializeField] private InputLogic inputLogic;
    [SerializeField] private InMemoryVariableStorage variableStorage;

     private string name = "";

    [YarnCommand("set_name")]
    public void SetName()
    {
        // Enable canvas
        cv.enabled = true;
        // Call the input logic function
        
        
    }
    
    public void Setter()
    {
        name = inputLogic.ReceiveInput();
        string _name;
        variableStorage.TryGetValue("$name", out _name);
        variableStorage.SetValue("$name", _name + name);
    }
}
