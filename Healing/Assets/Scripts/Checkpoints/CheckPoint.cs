using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Vector3 checkPointPos;
    [SerializeField]private PlayerMovement player;
    private bool enlight = true;

    // Start is called before the first frame update
    void Start()
    {
        checkPointPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SetCheckPoint(checkPointPos);
            if(enlight)
            {
                player.Enlight();
                enlight = false;
            }
            
        }
    }
}
