using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private float angleOffset = 180f; // �p�x�̃I�t�Z�b�g
    private Transform mainCameraTransform;

    void Start()
    {
        // ���C���J�������擾
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // �J�����Ƃ̕������擾���āA�r���{�[�h����]������
        Vector3 direction = mainCameraTransform.position - transform.position;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = lookRotation * Quaternion.Euler(0, angleOffset, 0);
    }
}