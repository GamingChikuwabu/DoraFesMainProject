using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �R�C�����v���C���[�ɋz�����܂��X�N���v�g
public class CoinAbsorption : MonoBehaviour
{
    [Header("�ړ���̑Ώ�")]
    [SerializeField] private GameObject Player;

    [Header("�z�����݃X�s�[�h")]
    [SerializeField] private float speed = 0.0f;

    [Header("�z�����ݔ͈�")]
    [SerializeField] private float range = 0.0f;

    // �R�C���ƃv���C���[�̋������i�[����ϐ�
    private float distance;

    private Vector3 targetPosition;

    void Update()
    {
        // �R�C���ƃv���C���[�̋���
        distance = Player.transform.position.z - transform.position.z;

        // ��Βl�����
        distance = Mathf.Abs(distance);

        // �R�C���ƃv���C���[�̋������z�����ݔ͈͂��Z��������
        if (distance < range)
        {
            // �R�C���̈ړ�����v���C���[�̈ʒu�ɐݒ肷��
            targetPosition = Player.transform.position;

            // �z�����܂��X�s�[�h
            float step = speed * Time.deltaTime;

            // Vector3.MoveTowards (��ƂȂ�J�n���W, ���B���������W, �ړ����x)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        }
    }
}
