using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    private GameObject audioObject;
    private AudioSource audio;
    [SerializeField] private AudioClip audioClip;
    private void Awake()
    {
        audioObject = GameObject.FindGameObjectWithTag("music");
        audio = audioObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audio.clip = audioClip;
        audio.Play();
    }
}
