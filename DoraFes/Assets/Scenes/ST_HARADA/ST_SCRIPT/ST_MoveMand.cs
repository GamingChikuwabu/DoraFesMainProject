using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_MoveMand : MonoBehaviour
{
    [Header("アニメーションの間隔")]
    public float intervalAnimation = 7f;
    // 待機時間中かどうかのフラグ
    bool isAnimation = false;


    [Header("アニメーションにかかる時間")]
    public float duration = 2f;
    [Header("地上に待機する時間")]
    public float duration02 = 2f;
    // 地上に待機するかどうかのフラグ
    bool isInterval = true;



    float startPosY;    // 開始位置を格納
    public float addNum = 20;
    float count;        // 時刻を格納
    bool isAnimPosi = true;


    


    void Start()
    {
        // 初期座標を格納
        startPosY = transform.position.y;
        count = Time.time;
    }

    void Update()
    {
        if (isAnimation)
        {
            bool act = false;

            // アニメーションの方向が正方向かどうか
            if (isAnimPosi)
            {
                act = ChangePos(count, duration, startPosY, startPosY + addNum);
                if (act)
                {
                    isAnimPosi = false;
                    count = Time.time;
                    isInterval = true;
                }
            }
            else
            {
                if (isInterval)
                {
                    // 待機中からアニメーションへ
                    if (Time.time - count >= duration02)
                    {
                        isInterval = false;
                        count = Time.time;
                    }
                }
                else
                {
                    act = ChangePos(count, duration, startPosY + addNum, startPosY);
                    if (act)
                    {
                        isAnimPosi = true;
                        count = Time.time;

                        isAnimation = false;
                    }
                }
            }
        }
        else
        {
            // 待機中からアニメーションへ
            if (Time.time - count > intervalAnimation) 
            {
                isAnimation = true;
                count = Time.time;
            }
        }
    }





    private bool ChangePos(float startTime, float duration, float startPow, float endPow)
    {
        // 現在の経過時間
        float elapsedTime = Time.time - startTime;

        // 経過時間を遷移時間で割り、0から1までの割合に変換
        float t = Mathf.Clamp01(elapsedTime / duration);

        // 変化前の値と変化後の値をtの割合で線形補間し座標を代入
        transform.position = new(
            transform.position.x,
            Mathf.Lerp(startPow, endPow, t),
            transform.position.z);

        // 規定時間が経過した？
        if (t == 1) return true;
        return false;
    }
}
