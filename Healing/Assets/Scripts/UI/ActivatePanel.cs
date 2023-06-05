using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public bool isMenuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
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
            isMenuActive = !isMenuActive;
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void DeActivateMenuOnClick()
    {
        isMenuActive = false;
        panel.SetActive(false);
    }

}
