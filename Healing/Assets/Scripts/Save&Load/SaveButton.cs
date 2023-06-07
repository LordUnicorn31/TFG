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
        Vector3 checkpoint = player.position;
        string scene = SceneManager.GetActiveScene().name;

        SaveData data = new SaveData(playerPos, lightRadius, checkpoint, jumpForce, scene);
        SaveManager.Instance.SaveGame(data);
    }
}
