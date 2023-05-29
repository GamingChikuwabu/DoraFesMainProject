using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour
{
    [Header("ワールド毎のオブジェクトを渡す")]
    [SerializeField] GameObject[] objStage;

    [Header("セーブデータを渡す")]
    public SaveData saveData;

    [Header("UIを渡す")]
    [SerializeField] GameObject[] objUI;

    int world;
    int stage;

    int selectWorld;

    void Start()
    {
        // クリア状況を格納
        string act = saveData.GetString();

        if (act == null)
        {
            world = 1;
            stage = 1;
        }
        else
        {
            world = int.Parse(act.Substring(0, 1)); // ワールド
            stage = int.Parse(act.Substring(2, 1)); // ステージ
        }
    }


    void Update()
    {
        
    }
}
