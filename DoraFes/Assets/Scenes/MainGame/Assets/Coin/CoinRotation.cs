using UnityEngine;

public class CoinRotation : MonoBehaviour
{
   
    public float rotateSpeed = 100f; // ��]���x

    private void Update()
    {
        //��]����
        transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
    }
}