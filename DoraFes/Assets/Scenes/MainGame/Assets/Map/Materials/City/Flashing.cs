using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]

public class Flashing : MonoBehaviour
{
    public Material targetMaterial; // 変更したいマテリアル
    public Material targetMaterial2; // 変更したいマテリアル

    private Renderer renderer; // オブジェクトのレンダラーコンポーネント

    public float minInterval = 1f; // 実行間隔の最小値
    public float maxInterval = 5f; // 実行間隔の最大値
    private float nextExecutionTime; // 次の実行時刻
    void Start()
    {
        renderer = GetComponent<Renderer>();
        // 初期の実行時刻を設定する
        SetNextExecutionTime();
    }



    void Update()
    {

        //if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.A))
        if (Time.time >= nextExecutionTime)
        {
            renderer.material = targetMaterial;
            SetNextExecutionTime();
        }
        else
        {

            renderer.material = targetMaterial2;


        }




    }

    private void SetNextExecutionTime()
    {
        // ランダムな実行間隔を生成する
        float interval = UnityEngine.Random.Range(minInterval, maxInterval);

        // 次の実行時刻を計算する
        nextExecutionTime = Time.time + interval;
    }

}
