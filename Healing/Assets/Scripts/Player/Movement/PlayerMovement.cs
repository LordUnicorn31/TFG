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
    public bool options = false;
    public float jumpForce = 6.0f;
    public bool notLoaded = false;
    private bool isTalking = false;
    [SerializeField] private float lightRadius = 0.5f;
    [SerializeField] private FadeOut fadeOut;
    [SerializeField]private GameObject light;
    private Animator anim;
    private Rigidbody2D rb;

    public Vector3 position;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        horMovement = GetComponent<HorizontalMovement>();
        jump = GetComponent<Jump>();
        fall = GetComponent<Fall>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isTalking || options)
        {
            
            anim.SetBool("isRunning", false);
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            return;
        }
        else
        {
            horMovement.Movement();
            jump.Jumping();
        }
        
    }

    private void FixedUpdate()
    {
        if (isTalking || options) return;
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
        position = data.lastCheckpoint;
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