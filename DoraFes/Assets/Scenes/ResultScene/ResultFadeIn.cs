using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultFadeIn : MonoBehaviour
{
    public Image fadeImage; // フェード用のイメージ

    [Header("スピード")]
    [SerializeField]private float fadeSpeed = 1f; // フェードの速度

    private float targetAlpha = 0f; // フェードの目標のアルファ値

    void Start()
    {
        // フェード用のイメージのアルファ値を初期化
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        // フェードインを開始
        StartFadeIn();
    }

    void Update()
    {
        // フェードイメージのアルファ値を目標値に向かって徐々に変化させる
        Color color = fadeImage.color;
        float newAlpha = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
        color.a = newAlpha;
        fadeImage.color = color;
    }

    void StartFadeIn()
    {
        targetAlpha = 0f; // フェードインの目標のアルファ値を0に設定
    }
}
