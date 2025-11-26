using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour
{
    public Color initialColor;
    public Color endColor;

    public float fadeDuration = 3f;
    public float fadeDelay = 0.5f;

    private Color c;

    void Start() => StartCoroutine(FadeAction());

    private IEnumerator FadeAction()
    {
        c = initialColor;
        yield return new WaitForSeconds(fadeDelay);

        float counter = fadeDuration;
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            c = Color.Lerp(endColor, initialColor, counter/fadeDuration);
            yield return null;
        }

        c = endColor;
    }

    void OnGUI()
    {
        GUI.color = c;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
    }
}
