using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    private GameObject playerObject;
    private PlayerMovement player;

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
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
