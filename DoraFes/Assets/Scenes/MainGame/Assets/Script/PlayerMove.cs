using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //目標にするオブジェクト
    private GameObject landmark;
    //ランマークの移動量を取得するスクリプト
    private LandMarkMove LM;
    //自分のRigidBody
    private Rigidbody myrig;
    //ジャンプのフラグ
    private bool Isjump = false;

    [Header("ジャンプ力")]
    [SerializeField]
    private float jumpPower = 5.0f;

    [Header("重力への影響度")]
    [SerializeField]
    private float affectGravity = 2.0f;

    private void Start()
    {
        //目標オブジェクトの取得
        landmark = GameObject.Find("LandMark");
        //LandMarkMoveスクリプトの取得
        LM = landmark.GetComponent<LandMarkMove>();
        //自分のRigidBodyの取得
        myrig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //目標オブジェクトの移動量の取得
        if(Input.anyKeyDown)
        {
            myrig.velocity = (new Vector3(LM.GetMovePower(), myrig.velocity.y, myrig.velocity.z));
        }
        //前方方向の進み具合を加算する
        myrig.velocity = new Vector3(myrig.velocity.x, myrig.velocity.y, LM.LandMarkSpeed);
        //ジャンプの処理
        if(Input.GetKeyDown(KeyCode.Space) && !Isjump)
        {
            //上方向へのちからを加える
            myrig.AddForce(new Vector3(0.0f, jumpPower, 0.0f),ForceMode.Impulse);
            //Isjumpをtrueにする
            Isjump = true;
        }
        //重力を強めるための処理
        myrig.AddForce(0.0f, -affectGravity, 0.0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //フラグを直す
        Isjump = false;
    }
}
