using System.Collections;
using UnityEngine;

public class CloudFadeIn : MonoBehaviour
{
    Renderer[] renderers;
    float timeout = 0.05f;
    float fadeDurationInSeconds = 1f;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float fadeAmount = 1 / (fadeDurationInSeconds / timeout);

        for (float f = fadeAmount; f <= 1; f += fadeAmount)
        {
            foreach (Renderer renderer in renderers)
            {
                Color c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
            }
            yield return new WaitForSeconds(timeout);
        }
    }
}
