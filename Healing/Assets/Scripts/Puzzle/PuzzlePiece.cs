using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private bool isMoving = false;
    private bool isCorrectPos = false;
    private Vector3 startPos;

    public Vector3 correctPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnMouseDown()
    {
        isMoving = true;

        transform.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }

    private void OnMouseUp()
    {
        isMoving = false;
        transform.GetComponent<SpriteRenderer>().sortingOrder = 5;

        PosChecker();
    }

    private void OnMouseDrag()
    {
        if(isMoving)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    private void PosChecker()
    {
        Vector3 gCorrectPos = transform.parent.TransformPoint(correctPos);
        if(Mathf.Abs(Vector3.Distance(transform.position, gCorrectPos)) < 0.5f)
        {
            transform.position = gCorrectPos;
            isCorrectPos = true;
            transform.GetComponent<SpriteRenderer>().color = Color.green;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.GetComponent<Puzzle>().AddCorrectPiece();
            transform.GetComponent<PuzzlePiece>().enabled = false;
            
        }

        else
        {
            transform.position = startPos;
        }
    }
}
