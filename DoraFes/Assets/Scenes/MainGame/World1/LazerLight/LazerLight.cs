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

    private bool rotateUp = true; //������ɉ�]���邩�ǂ����̃t���O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //���t���[�����Ƃ̉�]�ʂ��v�Z
        float rotationAmount = rotationSpeed * Time.deltaTime;

        //�������]�̏ꍇ
        if(rotateUp)
        {
            //�I�u�W�F�N�g����]������
            transform.Rotate(Vector3.forward, rotationAmount); //y����]
            //transform.Rotate(Vector3.up, rotationAmount);      x����]

            

            //�������]��60�x�ȏ�ɂȂ�����t���O��؂�ւ���
            if (transform.rotation.eulerAngles.z >= upLimit)
                rotateUp = false;
        }
        //��������]�̏ꍇ
        else
        {
            // �I�u�W�F�N�g����]������
            transform.Rotate(Vector3.forward, -rotationAmount);

            // ��������]��60�x�ȉ��ɂȂ�����t���O��؂�ւ���
            if (-transform.rotation.eulerAngles.z >= -downLimit)
                rotateUp = true;
        }
        
    }
}
