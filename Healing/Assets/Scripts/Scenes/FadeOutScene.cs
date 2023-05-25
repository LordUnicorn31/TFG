using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeOutScene : MonoBehaviour
{
    public Image fadeOutImage;
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        fadeOutImage.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeOut()
    {
        fadeOutImage.CrossFadeAlpha(1.0f, 3.0f, false);

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(sceneName);
    }

}
