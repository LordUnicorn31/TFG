using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    private int numCorrectPieces = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject piece in puzzlePieces)
        {
            piece.GetComponent<PuzzlePiece>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCorrectPiece()
    {
        numCorrectPieces++;
        if(numCorrectPieces == puzzlePieces.Length)
        {
            Debug.Log("Puzzle Completed");
        }
    }
}
