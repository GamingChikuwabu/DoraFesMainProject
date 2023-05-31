using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    [Header("���|�b�v���W")]
    [SerializeField] private float repopPosition;

    [Header("�G���h���W")]
    [SerializeField] private float endPosition;

    [Header("�X�s�[�h")]
    [SerializeField] private float speed = 10.0f;

    [Header("�E�ɐi�ނȂ�`�F�b�N")]
    [SerializeField] private bool moveRight;

    private Rigidbody rb;

    private Vector3 initialPosition;  // ���̈ʒu

    private float timeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        initialPosition = transform.position;
        initialPosition.x = repopPosition;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �ړ��������w��i�Ⴆ�΁A�E�����Ɉړ��j
        Vector3 movement = new Vector3(1f, 0f, 0f);


        // �ړ������ɑ��x����Z
        movement *= speed;

        if (moveRight)
        {
            // Rigidbody��velocity�v���p�e�B��ݒ�
            rb.velocity = movement;
        }
        else
        {
            // Rigidbody��velocity�v���p�e�B��ݒ�
            rb.velocity = -movement;
        }
        

        // �ړ��������������l�𒴂����猳�̈ʒu�ɖ߂�
        if (transform.position.x < endPosition)
        {
            //isMoving = false;
            Invoke("MoveBack", 0.1f);  // 1�b��Ɍ��̈ʒu�ɖ߂��������Ăяo���i�C�ӂ̑҂����ԁj
        }

    }
    private void MoveBack()
    {
        // ���̈ʒu�ɖ߂�
        transform.position = initialPosition;
       
    }
}
