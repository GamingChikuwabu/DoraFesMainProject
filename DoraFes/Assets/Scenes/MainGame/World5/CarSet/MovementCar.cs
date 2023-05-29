using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    public float moveDistance = 10f;  // �ړ����鋗��
    public float moveSpeed = 5f;  // �ړ����x

    private Vector3 initialPosition;  // ���̈ʒu
    private bool isMoving;  // �ړ������ǂ����̃t���O
    private float movedDistance = 0f;  // �ړ����������̗݌v

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            // x�����Ɉړ�����
            float moveStep = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveStep);

            // �ړ������������X�V
            movedDistance += Mathf.Abs(moveStep);
            

            // �ړ��������������l�𒴂����猳�̈ʒu�ɖ߂�
            if (movedDistance >= moveDistance)
            {
                //isMoving = false;
                Invoke("MoveBack", 0.1f);  // 1�b��Ɍ��̈ʒu�ɖ߂��������Ăяo���i�C�ӂ̑҂����ԁj
            }
        }
    }
    private void MoveBack()
    {
        // ���̈ʒu�ɖ߂�
        transform.position = initialPosition;
        movedDistance = 0f;  // �ړ��������������Z�b�g
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
