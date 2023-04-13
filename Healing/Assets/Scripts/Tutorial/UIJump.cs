using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJump : MonoBehaviour
{
    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkTutorial();
    }

    private void checkTutorial()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jump = true;

        if (jump) gameObject.SetActive(false);
    }
}
