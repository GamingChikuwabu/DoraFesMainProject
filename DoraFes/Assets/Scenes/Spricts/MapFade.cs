using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MapFade : MonoBehaviour
{

    [SerializeField] private float fadeStartTime = 0f;

    [SerializeField] private float fadeDurationIn = 1f;

    [SerializeField] private float fadeDurationOut = 1f;

    [SerializeField] private Image fadeImage;

    private bool isFading = false; // フェード中かどうかを示すフラグ

    public bool IsFading { get { return isFading; } } // フェード中かどうかを取得する

    private void Start()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f); // フェード画像のアルファ値を1に設定する
    }

    public IEnumerator FadeIn()
    {
        isFading = true; // フェード中フラグをONにする
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);

        yield return new WaitForSecondsRealtime(fadeStartTime);

        float t = 0f;
        while (t < fadeDurationIn)
        {
            t += Time.unscaledDeltaTime;
            float alpha = 1f - Mathf.Clamp01(t / fadeDurationIn);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
        isFading = false; // フェード中フラグをOFFにする
    }

    public IEnumerator FadeOut()
    {
        isFading = true; // フェード中フラグをONにする
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);

        yield return new WaitForSecondsRealtime(fadeStartTime);

        float t = 0f;
        while (t < fadeDurationOut)
        {
            t += Time.unscaledDeltaTime;
            float alpha = Mathf.Clamp01(t / fadeDurationOut);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
        isFading = false; // フェード中フラグをOFFにする
    }

    public IEnumerator FadeOutAndIn()
    {

        yield return StartCoroutine(FadeOut()); // フェードアウトする

        yield return new WaitUntil(() => !isFading); // フェード中でなくなるまで待機する

        yield return new WaitForSecondsRealtime(0.5f); // 0.5秒待機する

        yield return StartCoroutine(FadeIn()); // フェードインする
    }
}
