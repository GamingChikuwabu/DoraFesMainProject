using System.Diagnostics;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject subCamera;
    [SerializeField] GameObject Canvas;
    private void OnTriggerStay(Collider other)
    {
        // もし対象のオブジェクトに触れたら
        //void OnCollisionEnter(Collision collision)
        //{
            mainCamera.SetActive(!mainCamera.activeSelf);
            Canvas.SetActive(false);
    }
   
}
