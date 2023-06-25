using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredPlatform : MonoBehaviour
{

    private bool inRange = false;
    private BoxCollider2D collider;
    private Material material;
    private MovingPlatform movingPlat;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        material = GetComponent<SpriteRenderer>().material;
        movingPlat = GetComponent<MovingPlatform>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
            material.shader = Shader.Find("Sprites/Default");
            collider.enabled = true;
            movingPlat.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = false;
            material.shader = Shader.Find("Custom/Blurr");
            collider.enabled = false;
            movingPlat.enabled = false;
        }
    }
}
