using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public bool isMenuActive = false;
    private GameObject playerObj;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();
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
            player.options = !player.options;
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void DeActivateMenuOnClick()
    {
        player.options = false;
        isMenuActive = false;
        panel.SetActive(false);
    }

}
