using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredPlatform : MonoBehaviour
{

    private bool inRange = false;
    BoxCollider2D collider;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollider();
    }

    private void CheckCollider()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            collider.enabled = !collider.enabled;
            if(collider.enabled == true)
            {
                material.shader = Shader.Find("Sprites/Default");
            }

            else
            {
                material.shader = Shader.Find("Custom/Blurr");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = false;
        }
    }
}
