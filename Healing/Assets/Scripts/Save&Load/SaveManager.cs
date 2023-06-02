using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string saveFilePath = "save.dat";
    
    public static void SaveGame(SaveData data)
    {
        BinaryFormatter binFormat = new BinaryFormatter();
        FileStream fileStr = File.Create(Application.persistentDataPath + "/" + saveFilePath);

        binFormat.Serialize(fileStr, data);
        fileStr.Close();
    }

    public static SaveData LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/" + saveFilePath))
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            FileStream fileStr = File.Open(Application.persistentDataPath + "/" + saveFilePath, FileMode.Open);

            SaveData data = (SaveData)binFormat.Deserialize(fileStr);
            fileStr.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found");
            return new SaveData();
        }
    }

    public static void DeleteSave()
    {
        if(File.Exists(Application.persistentDataPath + "/" + saveFilePath))
        {
            File.Delete(Application.persistentDataPath + "/" + saveFilePath);
        }
        else
        {
            Debug.Log("Save file not found");
        }
    }
}
