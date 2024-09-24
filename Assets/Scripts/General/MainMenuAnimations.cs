using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnimations : MonoBehaviour
{
    public Image[] backgrounds; 
    public float fadeDuration = 2f; 
    public float moveSpeed = 0.1f; 

    private int currentBackgroundIndex = 0;
    private int nextBackgroundIndex;
    private float fadeTimer = 0f;

    private void Start()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (i != currentBackgroundIndex)
            {
                SetImageAlpha(backgrounds[i], 0f); 
            }
        }

        nextBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Length;
    }

    private void Update()
    {
        MoveBackgrounds();

        fadeTimer += Time.deltaTime / fadeDuration;
        float alpha = Mathf.Lerp(0f, 1f, fadeTimer); 

        SetImageAlpha(backgrounds[currentBackgroundIndex], 1f - alpha); 
        SetImageAlpha(backgrounds[nextBackgroundIndex], alpha); 

        if (fadeTimer >= 1f)
        {
            currentBackgroundIndex = nextBackgroundIndex;
            nextBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Length;

            fadeTimer = 0f;
        }
    }

    private void MoveBackgrounds()
    {
        foreach (Image background in backgrounds)
        {
            background.rectTransform.anchoredPosition += new Vector2(-moveSpeed * Time.deltaTime, 0f); 
        }
    }

    private void SetImageAlpha(Image img, float alpha)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
}
