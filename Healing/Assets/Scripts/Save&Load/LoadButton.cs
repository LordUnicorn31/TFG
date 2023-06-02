using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    
    public void LoadGame()
    {
        SaveData data = SaveManager.LoadGame();

        if(data.Equals(default(SaveData)))
        {
            Debug.Log("No save file found");
        }

        else
        {
            GameObject playerObject = Instantiate(playerPrefab);
            PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
            player.LoadData(data);
            Debug.Log("Game Loaded");
        }
              
    }
}
