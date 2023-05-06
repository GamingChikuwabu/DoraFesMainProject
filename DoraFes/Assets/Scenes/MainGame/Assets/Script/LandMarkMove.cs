using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkMove : MonoBehaviour
{ 
    //カメラ用のGameObject
    private GameObject ChildCamera;
    //目標点の進むスピード
    public float LandMarkSpeed = 5;
    //プレイヤーの左右移動の力
    public float PlayerMovePower = 3;
    //移動の減速率
    public float Decelerationrate = 0.1f;

    private float RetuerPlayerMovePower = 0;
    //このオブジェクトのRigidbody
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトのカメラを検索
        ChildCamera = transform.GetChild(0).gameObject;
        if(!ChildCamera)
        {
            Debug.Log("Child camera can not find");
        }

        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, LandMarkSpeed);

        if(Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector3(-PlayerMovePower, rig.velocity.y, rig.velocity.z);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector3(PlayerMovePower, rig.velocity.y, rig.velocity.z);
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x * Decelerationrate, rig.velocity.y, LandMarkSpeed);
        }
    }

    public float GetMovePower()
    {
        return RetuerPlayerMovePower;
    }
}
