using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]

public class Flashing : MonoBehaviour
{
    public Material targetMaterial; // �ύX�������}�e���A��
    public Material targetMaterial2; // �ύX�������}�e���A��

    private Renderer renderer; // �I�u�W�F�N�g�̃����_���[�R���|�[�l���g

    public float minInterval = 1f; // ���s�Ԋu�̍ŏ��l
    public float maxInterval = 5f; // ���s�Ԋu�̍ő�l
    private float nextExecutionTime; // ���̎��s����
    void Start()
    {
        renderer = GetComponent<Renderer>();
        // �����̎��s������ݒ肷��
        SetNextExecutionTime();
    }



    void Update()
    {

        //if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.A))
        if (Time.time >= nextExecutionTime)
        {
            renderer.material = targetMaterial;
            SetNextExecutionTime();
        }
        else
        {

            renderer.material = targetMaterial2;


        }




    }

    private void SetNextExecutionTime()
    {
        // �����_���Ȏ��s�Ԋu�𐶐�����
        float interval = UnityEngine.Random.Range(minInterval, maxInterval);

        // ���̎��s�������v�Z����
        nextExecutionTime = Time.time + interval;
    }

}
