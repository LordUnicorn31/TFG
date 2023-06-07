using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Vector3 checkPointPos;
    private GameObject playerObj;
    private PlayerMovement player;
    [SerializeField] private float jumpForce = 0.5f;
    private bool enlight = true;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        checkPointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SetCheckPoint(checkPointPos);       
            if(enlight)
            {
                player.Enlight();
                player.jumpForce += jumpForce;
                enlight = false;
            }
            
        }
    }
}
