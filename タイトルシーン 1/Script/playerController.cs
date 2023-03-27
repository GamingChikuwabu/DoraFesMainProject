using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //移動量
    [Header("加速力")]
    [SerializeField]
    private float AccelerationForce = 3;

    [Header("最大スピード")]
    [SerializeField]
    private float MaxSpeed = 5;

    [Header("ジャンプ力")]
    [SerializeField]
    private float JumpPawer = 10;

    //PlayerのRigidbody
    private Rigidbody rig;

    private bool JumpFlg;

    // Start is called before the first frame update
    void Start()
    {
        JumpFlg = true;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rig.AddForce(new Vector3(-AccelerationForce, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(new Vector3(AccelerationForce, 0.0f, 0.0f));
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(JumpFlg)
            {
                rig.AddForce(new Vector3(0.0f, JumpPawer, 0.0f), ForceMode.Impulse);
                JumpFlg = false;
            }

           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        JumpFlg = true;
    }
}