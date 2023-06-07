using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    // I store the data as strings because keys do not accept complex variables like vectors
    private string playerPositionKey = "PlayerPosition";
    private string jumpForceKey = "JumpForce";
    private string checkpointKey = "Checkpoint";
    private string lightRadiusKey = "LightRadius";
    private string sceneKey = "Scene";

    //Singleton
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SaveGame(SaveData data)
    {
        // I use PlayerPrefs class because it allows me to save data from game session to game session 
        PlayerPrefs.SetString(playerPositionKey, data.playerPosition.ToString());
        PlayerPrefs.SetFloat(jumpForceKey, data.jumpForce);
        PlayerPrefs.SetString(lightRadiusKey, data.lightRadius.ToString());
        PlayerPrefs.SetString(checkpointKey, data.lastCheckpoint.ToString());
        PlayerPrefs.SetString(sceneKey, data.scene);
        PlayerPrefs.Save();
        Debug.Log("Game saved");
    }

    public SaveData LoadGame()
    {
        if(PlayerPrefs.HasKey(playerPositionKey) && PlayerPrefs.HasKey(jumpForceKey) && PlayerPrefs.HasKey(lightRadiusKey) && PlayerPrefs.HasKey(sceneKey))
        {
            Vector3 playerPos = StringToVector3(PlayerPrefs.GetString(playerPositionKey));
            string currScene = PlayerPrefs.GetString(sceneKey);
            float jumpForce = PlayerPrefs.GetFloat(jumpForceKey);
            Vector3 lightRadius = StringToVector3(PlayerPrefs.GetString(lightRadiusKey));
            Vector3 checkpoint = StringToVector3(PlayerPrefs.GetString(checkpointKey));
            SaveData data = new SaveData(playerPos, lightRadius, checkpoint, jumpForce, currScene);
            Debug.Log("Game loaded");
            return data;
            
        }
        else
        {
            Debug.Log("No save file found");
            return null;
        }
    }

    private Vector3 StringToVector3(string vectString)
    {
        // Function to convert from string to vector·
        vectString = vectString.Replace("(", "").Replace(")", "");
        string[] values = vectString.Split(',');
        float x = float.Parse(values[0], CultureInfo.InvariantCulture);
        float y = float.Parse(values[1], CultureInfo.InvariantCulture);
        float z = float.Parse(values[2], CultureInfo.InvariantCulture);
        return new Vector3(x, y, z);

    }
}
