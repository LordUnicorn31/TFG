using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerMovement player;
    public void SaveGame()
    {
        Vector3 playerPos = playerObject.transform.position;
        player = playerObject.GetComponent<PlayerMovement>();
        float jumpForce = player.jumpForce;
        Vector3 lightRadius = playerObject.transform.GetChild(0).gameObject.transform.localScale;
        string scene = SceneManager.GetActiveScene().name;

        SaveData data = new SaveData(playerPos, lightRadius, jumpForce, scene);
        Debug.Log("Game saved");
    }
}
