using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMove : MonoBehaviour
{
    //自分のRigidBody
    private Rigidbody myrig;
    //自分がついていくのに目標にするオブジェクトのポジション
    private GameObject Landmark;
    //自分がついていくのに目標にするオブジェクトとの距離
    private Vector3 offset;

    private MainPlayerMove mpm;

    [Header("目標点を追いかけるスピード値が高いとすぐに追いつく")]
    [SerializeField]
    private float ChaseSpeed = 3;

    private void Start()
    {
        //自分のRigidBodyの取得
        myrig = GetComponent<Rigidbody>();

        mpm = Landmark.GetComponent<MainPlayerMove>();
    }

    private void Update()
    {
        //基準点の設定
        Vector3 temppoint = Landmark.transform.position - new Vector3(offset.x,offset.y, offset.z - mpm.Fowardvelocity);
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
