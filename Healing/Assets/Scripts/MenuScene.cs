using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        DestroyPlayer();
    }

    private void DestroyPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
    }
}
