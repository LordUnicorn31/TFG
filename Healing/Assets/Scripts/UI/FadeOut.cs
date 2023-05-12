using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    private Image image;
    private float targetAlpha = 1.0f;
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        FadeOutFX();
    }

    private void FadeOutFX()
    {
        if(isFading)
        {
            float alpha = Mathf.Lerp(image.color.a, targetAlpha, speed * Time.deltaTime);
            image.color = new Color(0.0f, 0.0f, 0.0f, alpha);

            if(Mathf.Abs(image.color.a-targetAlpha) < 0.01f)
            {
                isFading = false;
            }
        }
    }

    public void StartFadeOut()
    {
        isFading = true;
        targetAlpha = 1.0f;
    }
}
