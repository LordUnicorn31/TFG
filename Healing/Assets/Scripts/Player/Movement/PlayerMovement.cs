using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
    private HorizontalMovement horMovement;
    private Jump jump;
    private Fall fall;
    public bool loaded = false;
    private bool options = false;
    public float jumpForce;
    public bool notLoaded = false;
    private bool isTalking = false;
    [SerializeField] private float lightRadius = 0.5f;
    [SerializeField] private FadeOut fadeOut;
    [SerializeField]private GameObject light;
    private GameObject optionsMenu;

    public Vector3 position;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        optionsMenu = GameObject.FindGameObjectWithTag("Options");
    }
    // Start is called before the first frame update
    void Start()
    {
        horMovement = GetComponent<HorizontalMovement>();
        jump = GetComponent<Jump>();
        fall = GetComponent<Fall>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isTalking) return;
        else
        {
            horMovement.Movement();
            jump.Jumping();
        }
        
    }

    private void FixedUpdate()
    {
        if (isTalking) return;
        else
        {
            fall.Falling();
        }
        
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
        SaveData data = null;

        data.playerPosition = transform.position;
        data.jumpForce = 10.0f;
        data.lightRadius = light.transform.localScale;
        data.scene = SceneManager.GetActiveScene().name;

        return data;
    }

    public void LoadData(SaveData data)
    {
        Debug.Log("Loading data");
        loaded = true;
        this.gameObject.transform.position = data.playerPosition;
        jumpForce = data.jumpForce;
        light.transform.localScale = data.lightRadius;
    }

    [YarnCommand("isTalking")]
    public void IsTalking()
    {
        isTalking = true;
    }

    [YarnCommand("isNotTalking")]
    public void IsNotTalking()
    {
        isTalking = false;
    }
}