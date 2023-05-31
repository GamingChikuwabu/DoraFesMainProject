using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnFadeOut : MonoBehaviour
{
    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    public Image fadeImage; // フェード用のイメージ
    public float fadeSpeed = 1f; // フェードの速度

    private float targetAlpha; // フェードの目標のアルファ値

    void Start()
    {
        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

        // フェード用のイメージのアルファ値を初期化
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }

    void Update()
    {
        if (targetAlpha == 1.0f)
        {
            // フェードイメージのアルファ値を目標値に向かって徐々に変化させる
            Color color = fadeImage.color;
            float newAlpha = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            color.a = newAlpha;
            fadeImage.color = color;

            if (color.a == 1.0f)
            {
                LS.SetLoadName("StageSelect");
            }
        }

    }

    public void StringFadeOut()
    {

        targetAlpha = 1f;
    }
}
