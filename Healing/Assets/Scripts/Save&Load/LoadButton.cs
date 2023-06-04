using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadButton : MonoBehaviour
{
    public string menuScene = "Menu";
    public GameObject playerPrefab;

    public void LoadGame()
    {
        SaveData data = SaveManager.Instance.LoadGame();

        if(data != null)
        {
            SceneManager.LoadScene(data.scene);
            StartCoroutine(InstantiatePlayer(data));
        }
        else
        {
            Debug.Log("No save file found");
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    private IEnumerator InstantiatePlayer(SaveData sData)
    {
        yield return new WaitForEndOfFrame();

        GameObject playerObj = Instantiate(playerPrefab, sData.playerPosition, Quaternion.identity);
        Debug.Log("player instantiated");
        PlayerMovement player = playerObj.GetComponent<PlayerMovement>();

        if(player != null)
        {
            player.LoadData(sData);
        }
        else
        {
            Debug.Log("PlayerMovement component not found");
        }
    }
}
