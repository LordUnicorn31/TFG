using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputLogic : MonoBehaviour
{
    public InputField inputField;
    public Text outputText;

    private string playerInput;
    public void GetInput()
    {
        // Activate UI render (I DO NOT LIKE THIS D:)
        
        playerInput = inputField.text;
        // Debug text check
        outputText.text = playerInput;  
    }

    public string ReceiveInput()
    {
        return playerInput;
    }
    
    public void CleanUp()
    {
        Destroy(gameObject);
    }
}
