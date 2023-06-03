using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // This script aims to manage all the objects in DontSetroyOnLoad in each scene
    private GameObject player;
    [SerializeField] Vector3 playerPos;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerPos;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
