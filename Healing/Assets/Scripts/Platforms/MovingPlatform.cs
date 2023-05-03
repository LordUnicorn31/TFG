using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isMoving = false;
    private bool isPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isMoving = true;
    }

    private void OnMouseUp()
    {
        isMoving = false;
    }

    private void OnMouseDrag()
    {
        if(isMoving && !isPlayer)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // We dont want the platform to move when the player is staying on it
        if(collision.collider.tag == "Player")
        {
            isPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isPlayer = false;
        }
    }
}
