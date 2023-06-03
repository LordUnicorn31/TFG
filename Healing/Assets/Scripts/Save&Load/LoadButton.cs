using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public string menuScene = "Menu";

    public void LoadGame()
    {
        SaveData data = SaveManager.Instance.LoadGame();

        if(data != null)
        {
            SceneManager.LoadScene(data.scene);
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
}
