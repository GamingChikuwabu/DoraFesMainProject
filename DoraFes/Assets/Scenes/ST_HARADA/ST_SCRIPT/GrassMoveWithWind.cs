using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoveWithWind : MonoBehaviour
{
    // 初期の角度
    [System.NonSerialized] public Vector3 startAngel;
    // 変化後の角度
    [System.NonSerialized] public Vector3 endAngle;

    [Header("傾けたい角度（x）")]
    [SerializeField] private float angle = 45f;

    void Start()
    {
        startAngel = transform.eulerAngles;
        // 傾いた後の角度を算出
        endAngle = new (transform.eulerAngles.x + angle, transform.eulerAngles.y, transform.eulerAngles.z);

        //transform.eulerAngles = new(transform.eulerAngles.x + angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public void GrassMove(float startTime, float duration, float startAngle, float endAngle)
    {
        // 現在の経過時間
        float elapsedTime = Time.time - startTime;

        // 経過時間を遷移時間で割り、0から1までの割合に変換
        float t = Mathf.Clamp01(elapsedTime / duration);

        // 新たな傾きを代入
        transform.eulerAngles = new (Mathf.Lerp(startAngle, endAngle, t),       // 変化前の値と変化後の値をtの割合で線形補間し傾きを算出, 
        90,
        -90);
    }
}
