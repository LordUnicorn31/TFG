using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TogglePanel();
    }

    private void TogglePanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

}
