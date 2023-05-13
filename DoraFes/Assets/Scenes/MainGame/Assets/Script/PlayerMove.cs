using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMove : MonoBehaviour
{
    //�����}�[�N�̈ړ��ʂ��擾����X�N���v�g
    private MainPlayerMove LM;
    //������RigidBody
    private Rigidbody myrig;
    //���������Ă����̂ɖڕW�ɂ���I�u�W�F�N�g�̃|�W�V����
    private GameObject Landmark;
    //���������Ă����̂ɖڕW�ɂ���I�u�W�F�N�g�Ƃ̋���
    private Vector3 offset;

    [Header("�ڕW�_��ǂ�������X�s�[�h�l�������Ƃ����ɒǂ���")]
    [SerializeField]
    private float ChaseSpeed = 3;

    [Header("�W�����v��")]
    [SerializeField]
    private float jumpPower = 5.0f;

    private void Start()
    {
        //�ڕW�I�u�W�F�N�g�̎擾
        GameObject landmark = GameObject.FindGameObjectWithTag("MainPlayer");
        //LandMarkMove�X�N���v�g�̎擾
        LM = landmark.GetComponent<MainPlayerMove>();
        //������RigidBody�̎擾
        myrig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //�W�����v�̏���
        if (LM.Isjump)
        {
            //������ւ̂������������
            //myrig.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode.Impulse);
        }
        //��_�̐ݒ�
        Vector3 temppoint = Landmark.transform.position - offset;
        //��_�Ǝ����̃|�W�V�����ňړ������x�N�g�����쐬
        Vector3 MoveVec = temppoint - transform.position;
        //�ړ���������������
        myrig.velocity = new(MoveVec.x * ChaseSpeed, MoveVec.y * 50, MoveVec.z);

    }

    public void SetLandmark(GameObject _landmark, Vector3 _offset)
    {
        Landmark = _landmark;
        offset = _offset;
    }
}
