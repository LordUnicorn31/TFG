using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private GameObject audio;
    private AudioSource audioSource;
    [SerializeField] private  Scrollbar scrollbar;
    private void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("music");
        audioSource = audio.GetComponent<AudioSource>();
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }
    private void OnScrollbarValueChanged(float value)
    {
        audioSource.volume = value;
    }
}
