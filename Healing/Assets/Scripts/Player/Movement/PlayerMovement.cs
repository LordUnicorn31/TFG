using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private HorizontalMovement horMovement;
    private Jump jump;
    private Fall fall;
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
}
