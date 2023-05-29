using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// summary
// フェードイン、フェードアウトを行うスクリプト
// 使い方 [１]　簡単に使う場合
// 1. フェードしたいものにFadeController.csをアタッチする
// 2. Fade Settingsの各項目を設定する
// 3. Fade SettingsのfadeImageに”これをアタッチしたオブジェクト”をアタッチする
// 
// 使い方 [２]　ロード用など関数呼び出しで使う場合
// 1. FadeController.csをアタッチしたオブジェクトを作成する
// 2. Fade Settingsの各項目を設定する
// 3. LoadSceneなど他の関数からFadeController.csの関数を呼び出す
//　例）FadeController fadeController = GameObject.Find("FadeController").GetComponent<FadeController>();
// /summary

public class FadeController : MonoBehaviour
{
    //フェードが終わった時に呼び出す関数
    public delegate void FadeComplite();


    [Header("Fade Settings")]
    //フェードを始めるまでの時間
    [SerializeField] private float fadeStartTime = 0f;
    //フェードインにかかる時間
    [SerializeField] private float fadeDurationIn = 1f;
    //フェードアウトにかかる時間
    [SerializeField] private float fadeDurationOut = 1f;
    //フェードに使う画像またはオブジェクト
    [SerializeField] private Image fadeImage;
    //フェードインかアウトかの判定
    [SerializeField] private bool isFadeIn = true;
    [SerializeField] private bool isFadeOut = false;

    private void Start()
    {
        //画像がアタッチされていない場合はエラーを出す
        if (fadeImage == null)
        {
            Debug.LogError("Please assign an image for fading in the FadeController script on " + gameObject.name);
            return;
        }



        //フェードイン
        if (isFadeIn)
        {
            StartCoroutine(FadeIn());
        }
        //フェードアウト
        else if (isFadeOut)
        {
            StartCoroutine(FadeOut());
        }
    }

    //========================
    //フェードイン
    //========================
    public IEnumerator FadeIn()
    {
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
    }

    //========================
    //フェードアウト
    //========================
    public IEnumerator FadeOut()
    {
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
    }
}
