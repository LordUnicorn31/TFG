using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeOutScene : MonoBehaviour
{
    public Image fadeOutImage;
    [SerializeField] string sceneName;
    [SerializeField] GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        fadeOutImage.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wrapper()
    {
        StartCoroutine(FadeOut());
        StopCoroutine(FadeOut());
    }

    public void WrapperInstantiate()
    {
        StartCoroutine(FadeOutInstantiate());
        StopCoroutine(FadeOutInstantiate());
    }

    private IEnumerator FadeOut()
    {
        fadeOutImage.CrossFadeAlpha(1.0f, 3.0f, false);

        yield return new WaitForSeconds(3.0f);
        
        SceneManager.LoadScene(sceneName);
        
    }

    private IEnumerator FadeOutInstantiate()
    {
        fadeOutImage.CrossFadeAlpha(1.0f, 3.0f, false);

        yield return new WaitForSeconds(3.0f);
        Instantiate(playerPrefab);
        SceneManager.LoadScene(sceneName);
    }

}
