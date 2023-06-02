using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    private PlayerMovement player;
    private GameObject playerObject;

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("player");
        player = playerObject.GetComponent<PlayerMovement>();
    }
    public void SaveGame()
    {
        SaveData data = player.Save();
        SaveManager.SaveGame(data);
        Debug.Log("Game saved");
    }
}
