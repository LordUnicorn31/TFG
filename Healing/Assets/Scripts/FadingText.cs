using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingText : MonoBehaviour
{
    [SerializeField] private float fadeInDuration = 1f;
    [SerializeField] private float fadeOutDuration = 1f;
    [SerializeField] private float displayDuration = 8f;
    [SerializeField] private float endGameDuration = 1f;

    private Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {

        float timer = 0f;
        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeInDuration;
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);
            yield return null;
        }


        yield return new WaitForSeconds(displayDuration);


        timer = 0f;
        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            float alpha = 1f - (timer / fadeOutDuration);
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);
            yield return null;
        }


        yield return new WaitForSeconds(endGameDuration);

        Application.Quit();
    }
}

