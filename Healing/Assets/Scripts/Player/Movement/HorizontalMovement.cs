using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    //variables
    public bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Movement()
    {
        float movement = GetMovementInput();
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);

        if (movement > 0 && !isFacingRight)
        {
            Flip();
        }

        else if (movement < 0 && isFacingRight)
        {
            Flip();
        }

        if (movement != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    public float GetMovementInput()
    {
        return Input.GetAxis("Horizontal");
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}

