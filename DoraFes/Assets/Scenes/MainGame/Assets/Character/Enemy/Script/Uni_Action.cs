using UnityEngine;

public class Uni_Action : MonoBehaviour
{
    public float speed = 10f; // 前進速度
    public float rotateSpeed = 500f; // 回転速度

    private void Update()
    {
        // 前進する
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position += Vector3.back * speed * Time.deltaTime;
        // X軸周りに回転する
        transform.Rotate(-Vector3.back * rotateSpeed * Time.deltaTime);

    }


}