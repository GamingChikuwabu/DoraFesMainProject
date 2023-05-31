using UnityEngine;

public class Uni_Action : MonoBehaviour
{
    public float speed = 10f; // �O�i���x
    public float rotateSpeed = 500f; // ��]���x

    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0.0f, 0.0f, -speed);
        rigidbody.angularVelocity = new Vector3(-rotateSpeed, 0.0f, 0.0f);
    }
}