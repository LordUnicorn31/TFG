using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Color backgroundColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camera.backgroundColor = backgroundColor;
        }
    }
}
