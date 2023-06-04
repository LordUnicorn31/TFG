using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // This script aims to manage all the objects in DontSetroyOnLoad in each scene
    private GameObject playerObj;
    private PlayerMovement player;
    [SerializeField] Vector3 playerPos;
    // Start is called before the first frame update

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();

        if (!player.loaded)
        {
            player.transform.position = playerPos;
        }

        else return;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
