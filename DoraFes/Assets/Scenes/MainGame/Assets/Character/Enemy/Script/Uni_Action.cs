using UnityEngine;

public class Uni_Action : MonoBehaviour
{
    public float speed = 10f; // �O�i���x
    public float rotateSpeed = 500f; // ��]���x

    private void Update()
    {
        // �O�i����
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position += Vector3.back * speed * Time.deltaTime;
        // X������ɉ�]����
        transform.Rotate(-Vector3.back * rotateSpeed * Time.deltaTime);

    }


}