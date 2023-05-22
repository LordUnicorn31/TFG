using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Vector3 checkPointPos;
    [SerializeField]private PlayerMovement player;
    private bool enlight = true;
    [SerializeField] GameObject background;
    private Tilemap tilemap;
    [SerializeField] Color backGroundColor;

    // Start is called before the first frame update
    void Start()
    {
        checkPointPos = transform.position;
        tilemap = background.GetComponent<Tilemap>();
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
                tilemap.color = backGroundColor;
                enlight = false;
            }
            
        }
    }
}
