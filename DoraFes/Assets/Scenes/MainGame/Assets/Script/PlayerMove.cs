using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMove : MonoBehaviour
{
    //������RigidBody
    private Rigidbody myrig;
    //���������Ă����̂ɖڕW�ɂ���I�u�W�F�N�g�̃|�W�V����
    private GameObject Landmark;
    //���������Ă����̂ɖڕW�ɂ���I�u�W�F�N�g�Ƃ̋���
    private Vector3 offset;

    private MainPlayerMove mpm;

    [Header("�ڕW�_��ǂ�������X�s�[�h�l�������Ƃ����ɒǂ���")]
    [SerializeField]
    private float ChaseSpeed = 3;

    private void Start()
    {
        //������RigidBody�̎擾
        myrig = GetComponent<Rigidbody>();

        mpm = Landmark.GetComponent<MainPlayerMove>();
    }

    private void Update()
    {
        //��_�̐ݒ�
        Vector3 temppoint = Landmark.transform.position - new Vector3(offset.x,offset.y, offset.z - mpm.Fowardvelocity);
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
