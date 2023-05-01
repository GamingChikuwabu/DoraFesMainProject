using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private float angleOffset = 180f; // 角度のオフセット
    private Transform mainCameraTransform;

    void Start()
    {
        // メインカメラを取得
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // カメラとの方向を取得して、ビルボードを回転させる
        Vector3 direction = mainCameraTransform.position - transform.position;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = lookRotation * Quaternion.Euler(0, angleOffset, 0);
    }
}