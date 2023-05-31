using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickNaturalMove : MonoBehaviour
{
    public float moveSpeed = 2f; // ˆÚ“®‘¬“x
    public float moveDistance = 4f; // ˆÚ“®‹——£

    private Vector3 originalPosition;
    private float timer = 0f;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void MoveStick()
    {
        timer += Time.deltaTime * moveSpeed;
        float yPos = originalPosition.y + Mathf.Sin(timer) * moveDistance;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
