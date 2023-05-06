using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkMove : MonoBehaviour
{ 
    //�J�����p��GameObject
    private GameObject ChildCamera;
    //�ڕW�_�̐i�ރX�s�[�h
    public float LandMarkSpeed = 5;
    //�v���C���[�̍��E�ړ��̗�
    public float PlayerMovePower = 3;
    //�ړ��̌�����
    public float Decelerationrate = 0.1f;

    private float RetuerPlayerMovePower = 0;
    //���̃I�u�W�F�N�g��Rigidbody
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g�̃J����������
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
