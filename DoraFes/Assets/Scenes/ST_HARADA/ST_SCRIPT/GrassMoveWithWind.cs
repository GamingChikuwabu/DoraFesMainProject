using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoveWithWind : MonoBehaviour
{
    // �����̊p�x
    [System.NonSerialized] public Vector3 startAngel;
    // �ω���̊p�x
    [System.NonSerialized] public Vector3 endAngle;

    [Header("�X�������p�x�ix�j")]
    [SerializeField] private float angle = 45f;

    void Start()
    {
        startAngel = transform.eulerAngles;
        // �X������̊p�x���Z�o
        endAngle = new (transform.eulerAngles.x + angle, transform.eulerAngles.y, transform.eulerAngles.z);

        //transform.eulerAngles = new(transform.eulerAngles.x + angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public void GrassMove(float startTime, float duration, float startAngle, float endAngle)
    {
        // ���݂̌o�ߎ���
        float elapsedTime = Time.time - startTime;

        // �o�ߎ��Ԃ�J�ڎ��ԂŊ���A0����1�܂ł̊����ɕϊ�
        float t = Mathf.Clamp01(elapsedTime / duration);

        // �V���ȌX������
        transform.eulerAngles = new (Mathf.Lerp(startAngle, endAngle, t),       // �ω��O�̒l�ƕω���̒l��t�̊����Ő��`��Ԃ��X�����Z�o, 
        90,
        -90);
    }
}
