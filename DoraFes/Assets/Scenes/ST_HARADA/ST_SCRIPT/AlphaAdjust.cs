using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAdjust : MonoBehaviour
{
    public float startValue = 0; // 初期値
    public float endtValue = 1.0f; // 変化後の値

    [Header("遷移にかかる時間")]
    [SerializeField] private float duration = 1f;
    float count = 0;
    int isPositive = 0;

    private Renderer renderer;

    [Header("自身のワールドナンバーを入れる")]
    public int myNumber;

    public GameObject stick;
    SelectWorld act;
    MeshRenderer meshRenderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        act = stick.GetComponent<SelectWorld>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    private void Update()
    {
        if (act.nowSelectWorld == myNumber)
        {
            meshRenderer.enabled = true;
            ChangeAlpha();
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    // α値を変更する関数
    private void ChangeAlpha()
    {
        // マテリアルのカラープロパティを取得
        Color color = renderer.material.color;

        // 現在の経過時間
        float elapsedTime = Time.time - count;

        // 経過時間を遷移時間で割り、0から1までの割合に変換
        float t = Mathf.Clamp01(elapsedTime / duration);
        if (isPositive % 2 == 0) color.a = Mathf.Lerp(startValue, endtValue, t);
        else color.a = Mathf.Lerp(endtValue, startValue, t);

        // 変更したカラープロパティをマテリアルに設定
        renderer.material.color = color;

        // 規定時間が経過した？
        if (t == 1)
        {
            isPositive++;
            count = Time.time;
        }
    }
}
