using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�ڕW�ɂ���I�u�W�F�N�g
    private GameObject landmark;
    //�����}�[�N�̈ړ��ʂ��擾����X�N���v�g
    private LandMarkMove LM;
    //������RigidBody
    private Rigidbody myrig;
    //�W�����v�̃t���O
    private bool Isjump = false;

    [Header("�W�����v��")]
    [SerializeField]
    private float jumpPower = 5.0f;

    [Header("�d�͂ւ̉e���x")]
    [SerializeField]
    private float affectGravity = 2.0f;

    private void Start()
    {
        //�ڕW�I�u�W�F�N�g�̎擾
        landmark = GameObject.Find("LandMark");
        //LandMarkMove�X�N���v�g�̎擾
        LM = landmark.GetComponent<LandMarkMove>();
        //������RigidBody�̎擾
        myrig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //�ڕW�I�u�W�F�N�g�̈ړ��ʂ̎擾
        if(Input.anyKeyDown)
        {
            myrig.velocity = (new Vector3(LM.GetMovePower(), myrig.velocity.y, myrig.velocity.z));
        }
        //�O�������̐i�݋�����Z����
        myrig.velocity = new Vector3(myrig.velocity.x, myrig.velocity.y, LM.LandMarkSpeed);
        //�W�����v�̏���
        if(Input.GetKeyDown(KeyCode.Space) && !Isjump)
        {
            //������ւ̂������������
            myrig.AddForce(new Vector3(0.0f, jumpPower, 0.0f),ForceMode.Impulse);
            //Isjump��true�ɂ���
            Isjump = true;
        }
        //�d�͂����߂邽�߂̏���
        myrig.AddForce(0.0f, -affectGravity, 0.0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //�t���O�𒼂�
        Isjump = false;
    }
}
