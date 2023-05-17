using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickNaturalMove : MonoBehaviour
{
    [Header("—h‚ê•")]
    [SerializeField] private Vector3 move;

    public float moveSpeed = 1f; // ˆÚ“®‘¬“x
    public float moveDistance = 1f; // ˆÚ“®‹——£

    private Vector3 originalPosition;
    private float timer = 0f;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime * moveSpeed;
        float yPos = originalPosition.y + Mathf.Sin(timer) * moveDistance;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
