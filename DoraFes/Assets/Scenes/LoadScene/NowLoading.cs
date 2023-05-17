using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowLoading : MonoBehaviour
{
    [Header("�̕ʔԍ�")]
    [SerializeField] private int moveNum;

    //�ړ��X�s�[�h
    private float moveSpeed = 100;

    //�㏸�l�̏��
    private float upLimit = 20.0f;
    //�ԍ��̏��
    private int numLimit = 10;

    //�㏸����I�u�W�F�N�g�̔ԍ�
    private static int upNum;
    //���~����I�u�W�F�N�g�̔ԍ�
    private static int downNum;

    // �����ʒu
    private Vector3 startPosition ;

    // Start is called before the first frame update
    void Start()
    {
        upNum = 1; //�㏸������ԍ��̏����l
        downNum = 0; //���~������ԍ��̏����l
        startPosition = transform.position; //�����ʒu���Z�b�g���Ă���

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //moveNum��upNum����v�����I�u�W�F�N�g�����������
        if (moveNum == upNum)
        {
            //�����ŏ㏸������
            transform.Translate(0.0f, 0.0f, -moveSpeed * Time.deltaTime);

            //���ݒn�Ə����ʒu�̍������㏸�l�̏���𒴂��Ă�����
            if(transform.position.y - startPosition.y > upLimit)
            {
                upNum += 1;
                downNum += 1;
                if (upNum > numLimit)
                {
                    upNum = 1;
                }

                if (downNum > numLimit)
                {
                    downNum = 1;
                }
                
            }

        }

        //moveNum��downNum����v�����I�u�W�F�N�g�����~������
        if (moveNum == downNum)
        {
            transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
        }
    }
}
