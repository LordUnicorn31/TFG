using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private HorizontalMovement horMovement;
    private Jump jump;
    private Fall fall;
    [SerializeField] private float jumpForce;
    [SerializeField] private float lightRadius = 0.5f;
    [SerializeField] private FadeOut fadeOut;
    [SerializeField]private GameObject light;

    public Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        horMovement = GetComponent<HorizontalMovement>();
        jump = GetComponent<Jump>();
        fall = GetComponent<Fall>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetCheckPoint(Vector3 newPos)
    {
        position = newPos;
    }

    private void Die()
    {
        //fadeOut.StartFadeOut();
        transform.position = position;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            Die();
        }
    }

    public void Enlight()
    {
        lightRadius += 0.5f;
        light.transform.localScale = new Vector3(lightRadius, lightRadius, 0.0f);
    }

    public SaveData Save()
    {
        SaveData data;

        data.playerPosition = transform.position;
        data.jumpForce = 10.0f;
        data.lightRadius = light.transform.localScale;
        data.scene = SceneManager.GetActiveScene();

        return data;
    }

    public void LoadData(SaveData data)
    {
        SceneManager.LoadScene(data.scene.name);
        transform.position = data.playerPosition;
        jumpForce = data.jumpForce;
        light.transform.localScale = data.lightRadius;
    }

}
