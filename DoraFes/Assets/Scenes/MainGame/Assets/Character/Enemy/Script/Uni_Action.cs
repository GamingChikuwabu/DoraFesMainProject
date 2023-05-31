using UnityEngine;

public class Uni_Action : MonoBehaviour
{
    public float speed = 10f; // 前進速度
    public float rotateSpeed = 500f; // 回転速度

    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0.0f, 0.0f, -speed);
        rigidbody.angularVelocity = new Vector3(-rotateSpeed, 0.0f, 0.0f);
    }
}