using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public bool isJumping = false;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = gameObject.GetComponent<PlayerMovement>();
    }

    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
            anim.SetBool("isJumping", true);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }
    }
}
