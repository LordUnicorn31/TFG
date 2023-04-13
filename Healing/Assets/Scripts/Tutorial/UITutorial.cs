using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    private bool moveLeft = false;
    private bool moveRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTutorial();
    }

    private void CheckTutorial()
    {
        if (Input.GetKeyDown(KeyCode.A)) moveLeft = true;

        if (Input.GetKeyDown(KeyCode.D)) moveRight = true;

        if (moveLeft && moveRight) gameObject.SetActive(false);
    }
}
