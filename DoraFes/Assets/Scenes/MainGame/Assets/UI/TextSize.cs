using System.Diagnostics;
using UnityEngine;
using TMPro;

public class TextSize : MonoBehaviour
{
    public TMP_Text textComponent; // サイズを調整するテキストコンポーネント
    public float baseFontSize = 20f; // 初期のフォントサイズ
    public
    float sizePerDigit = 2f; // 桁数ごとのサイズの変化量

    private void Start()
    {
     
    }

    private void Update()
    {
        // テキストの桁数に基づいてフォントサイズを計算する
        int digitCount = textComponent.text.Length;
        float fontSize = baseFontSize - (digitCount * sizePerDigit);

        // フォントサイズを設定する
        textComponent.fontSize = Mathf.Max(fontSize, 1f); // 最小サイズを1にする（ゼロにならないようにする）
    }
}