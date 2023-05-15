using UnityEngine;

public class CoinRotation : MonoBehaviour
{
   
    public float rotateSpeed = 100f; // ‰ñ“]‘¬“x

    private void Update()
    {
        //‰ñ“]ˆ—
        transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
    }
}