using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMove : MonoBehaviour
{
    //ランマークの移動量を取得するスクリプト
    private MainPlayerMove LM;
    //自分のRigidBody
    private Rigidbody myrig;
    //自分がついていくのに目標にするオブジェクトのポジション
    private GameObject Landmark;
    //自分がついていくのに目標にするオブジェクトとの距離
    private Vector3 offset;

    [Header("目標点を追いかけるスピード値が高いとすぐに追いつく")]
    [SerializeField]
    private float ChaseSpeed = 3;

    [Header("ジャンプ力")]
    [SerializeField]
    private float jumpPower = 5.0f;

    private void Start()
    {
        //目標オブジェクトの取得
        GameObject landmark = GameObject.FindGameObjectWithTag("MainPlayer");
        //LandMarkMoveスクリプトの取得
        LM = landmark.GetComponent<MainPlayerMove>();
        //自分のRigidBodyの取得
        myrig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //ジャンプの処理
        if (LM.Isjump)
        {
            //上方向へのちからを加える
            //myrig.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode.Impulse);
        }
        //基準点の設定
        Vector3 temppoint = Landmark.transform.position - offset;
        //基準点と自分のポジションで移動距離ベクトルを作成
        Vector3 MoveVec = temppoint - transform.position;
        //移動成分を合成する
        myrig.velocity = new(MoveVec.x * ChaseSpeed, MoveVec.y * 50, MoveVec.z);

    }

    public void SetLandmark(GameObject _landmark, Vector3 _offset)
    {
        Landmark = _landmark;
        offset = _offset;
    }
}
