using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavesScene : MonoBehaviour
{
    private GameObject playerObj;
    private PlayerMovement player;
    [SerializeField] private Vector3 spawn;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player.notLoaded)
        {
            player.transform.position = spawn;
        }
        else return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
