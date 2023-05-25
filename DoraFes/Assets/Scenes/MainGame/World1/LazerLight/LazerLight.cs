using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerLight : MonoBehaviour
{
    [Header("��]�X�s�[�h")]
    [SerializeField]private float rotationSpeed = 20f;

    [Header("��]���(1�`90)")]
    [SerializeField] private float upLimit = 60f;

    [Header("��]����(1�`90)")]
    [SerializeField] private float downLimit = 10f;

    private bool rotateUp = false; //������ɉ�]���邩�ǂ����̃t���O

    //�����̉�]��ێ�����ϐ�
    private Quaternion initialRotation;
    private float initialZAngle;

    //�t�B�[�o�[�����𔻒肷��ϐ�
    private bool isFever;


    // Start is called before the first frame update
    void Start()
    {
        // �����̉�]��ێ�����
        initialRotation = transform.rotation;
        initialZAngle = GetZAngle(initialRotation);

        isFever = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //�t�B�[�o�[�����ǂ������i�[����
        //isFever=;

        if (isFever)
        {
            //�A�N�e�B�u�ɂ���


            //���t���[�����Ƃ̉�]�ʂ��v�Z
            float rotationAmount = rotationSpeed * Time.deltaTime;

            // ���݂̉�]����Z���̊p�x���擾���A�����̊p�x�Ƃ̍������߂�
            float currentZAngle = GetZAngle(transform.rotation);
            float zAngleDifference = GetShortestAngleDifference(initialZAngle, currentZAngle);

            //�������]�̏ꍇ
            if (rotateUp)
            {
                //�I�u�W�F�N�g����]������
                transform.Rotate(Vector3.forward, rotationAmount); //z����]
                                                                   //transform.Rotate(Vector3.up, rotationAmount);      y����]

                //�������]��60�x�ȏ�ɂȂ�����t���O��؂�ւ���
                if (zAngleDifference >= upLimit)
                    rotateUp = false;
            }
            //��������]�̏ꍇ
            else
            {
                // �I�u�W�F�N�g����]������
                transform.Rotate(Vector3.forward, -rotationAmount);

                // ��������]��60�x�ȉ��ɂȂ�����t���O��؂�ւ���
                if (-zAngleDifference >= -downLimit)
                    rotateUp = true;
            }
        }
        else
        {
            //��A�N�e�B�u�ɂ���
        }
        

        
    }

    // �N�H�[�^�j�I������Z���̊p�x���擾����w���p�[�֐�
    private float GetZAngle(Quaternion rotation)
    {
        return rotation.eulerAngles.z;
    }

    // �ŒZ�̊p�x�����v�Z����w���p�[�֐�
    private float GetShortestAngleDifference(float startAngle, float targetAngle)
    {
        float angleDifference = Mathf.DeltaAngle(startAngle, targetAngle);
        return angleDifference;
    }
}
