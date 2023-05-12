using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private HorizontalMovement horMovement;
    private Jump jump;
    private Fall fall;
    [SerializeField] private FadeOut fadeOut;

    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        horMovement = GetComponent<HorizontalMovement>();
        jump = GetComponent<Jump>();
        fall = GetComponent<Fall>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCheckPoint(Vector3 newPos)
    {
        position = newPos;
    }

    private void Die()
    {
        //fadeOut.StartFadeOut();
        transform.position = position;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            Die();
        }
    }

}
