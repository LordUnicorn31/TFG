using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData
{
    public Vector3 playerPosition;
    public Vector3 lightRadius;
    public Vector3 lastCheckpoint;
    public float jumpForce;
    public string scene;

    public SaveData(Vector3 playerPos, Vector3 lightRad, Vector3 lastCheck, float jumpF, string sc)
    {
        this.playerPosition = playerPos;
        this.lightRadius = lightRad;
        this.lastCheckpoint = lastCheck;
        this.jumpForce = jumpF;
        this.scene = sc;
    }
}
