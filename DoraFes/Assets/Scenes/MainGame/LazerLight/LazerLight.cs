using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerLight : MonoBehaviour
{
    [Header("回転スピード")]
    [SerializeField]private float rotationSpeed = 20f;

    [Header("回転上限(1〜90)")]
    [SerializeField] private float upLimit = 60f;

    [Header("回転下限(1〜90)")]
    [SerializeField] private float downLimit = 10f;

    private bool rotateUp = false; //上向きに回転するかどうかのフラグ

    //初期の回転を保持する変数
    private Quaternion initialRotation;
    private float initialZAngle;

    //フィーバー中かを判定する変数
    private bool isFever;

    //プレイヤーのGlobalStatusManagerスクリプトのisFeverを取得する変数
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;


    // Start is called before the first frame update
    void Start()
    {
        isFever = false;

        // 初期の回転を保持する
        initialRotation = transform.rotation;
        initialZAngle = GetZAngle(initialRotation);

        //Playerのスクリプトを取得する
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //アクティブにする
        gameObject.SetActive(true);

        //毎フレームごとの回転量を計算
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // 現在の回転からZ軸の角度を取得し、初期の角度との差を求める
        float currentZAngle = GetZAngle(transform.rotation);
        float zAngleDifference = GetShortestAngleDifference(initialZAngle, currentZAngle);
        float a = Mathf.Abs(zAngleDifference);

        //上向き回転の場合
        if (rotateUp)
        {
            //オブジェクトを回転させる
            transform.Rotate(Vector3.forward, -rotationAmount); //z軸回転
                                                                //transform.Rotate(Vector3.up, rotationAmount);      y軸回転

            //上向き回転が60度以上になったらフラグを切り替える
            if (a >= upLimit)
                rotateUp = false;
        }
        //下向き回転の場合
        else
        {
            // オブジェクトを回転させる
            transform.Rotate(Vector3.forward, rotationAmount);

            // 下向き回転が60度以下になったらフラグを切り替える
            if (-a >= -downLimit)
                rotateUp = true;
        }

        ////フィーバー中かどうかを格納する
        //isFever = GSM.IsFever;

        //if (isFever == true)
        //{
        //    //アクティブにする
        //    gameObject.SetActive(true);

        //    //毎フレームごとの回転量を計算
        //    float rotationAmount = rotationSpeed * Time.deltaTime;

        //    // 現在の回転からZ軸の角度を取得し、初期の角度との差を求める
        //    float currentZAngle = GetZAngle(transform.rotation);
        //    float zAngleDifference = GetShortestAngleDifference(initialZAngle, currentZAngle);
        //    float a = Mathf.Abs(zAngleDifference);

        //    //上向き回転の場合
        //    if (rotateUp)
        //    {
        //        //オブジェクトを回転させる
        //        transform.Rotate(Vector3.forward, -rotationAmount); //z軸回転
        //                                                           //transform.Rotate(Vector3.up, rotationAmount);      y軸回転

        //        //上向き回転が60度以上になったらフラグを切り替える
        //        if (a >= upLimit)
        //            rotateUp = false;
        //    }
        //    //下向き回転の場合
        //    else
        //    {
        //        // オブジェクトを回転させる
        //        transform.Rotate(Vector3.forward, rotationAmount);

        //        // 下向き回転が60度以下になったらフラグを切り替える
        //        if (-a >= -downLimit)
        //            rotateUp = true;
        //    }
        //}
        //else
        //{
        //    //非アクティブにする
        //    gameObject.SetActive(false);
        //}
        
    }

    // クォータニオンからZ軸の角度を取得するヘルパー関数
    private float GetZAngle(Quaternion rotation)
    {
        return rotation.eulerAngles.z;
    }

    // 最短の角度差を計算するヘルパー関数
    private float GetShortestAngleDifference(float startAngle, float targetAngle)
    {
        float angleDifference = Mathf.DeltaAngle(startAngle, targetAngle);
        return angleDifference;
    }
}
