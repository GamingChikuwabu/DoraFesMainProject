using UnityEngine;

public class CoinRotation : MonoBehaviour
{
   
    public float rotateSpeed = 100f; // 回転速度

    private void Update()
    {
        //回転処理
        transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
    }
}