using System.Diagnostics;
using UnityEngine;
using UnityDebug = UnityEngine.Debug;

public class ObjectActivator : MonoBehaviour
{
    // アクティブにするオブジェクトのタグ名
  
    [SerializeField] GameObject Block;
    [SerializeField] GameObject Block2;
    [SerializeField] GameObject Block3;
    [SerializeField] GameObject Block4;
    [SerializeField] GameObject Block5;
    public float triggerDistance = 150f; // カメラがこの距離以内に近づいたらオブジェクトをアクティブ化する

    private Transform cameraTransform; // カメラのTransformコンポーネント
   

    // カメラオブジェクト
    private Camera mainCamera;
  // Startメソッドでカメラオブジェクトを取得
    void Start()
    {
        mainCamera = Camera.main;

        // メインカメラのTransformコンポーネントを取得する
        cameraTransform = Camera.main.transform;
    }

    // アクティブにするオブジェクトを取得する
    void ActivateObjectsIfCameraNear()
    {       
        float distanceToCamera = Block.transform.position.z - cameraTransform.position.z;
        float distanceToCamera2 = Block2.transform.position.z - cameraTransform.position.z;
        float distanceToCamera3 = Block3.transform.position.z - cameraTransform.position.z;
        float distanceToCamera4 = Block4.transform.position.z - cameraTransform.position.z;
        float distanceToCamera5 = Block5.transform.position.z - cameraTransform.position.z;
        if (distanceToCamera <= triggerDistance)
        {
            Block.SetActive(true);
        }

        if (distanceToCamera2 <= triggerDistance*2)
        {
            Block2.SetActive(true);
        }
        if (distanceToCamera3 <= triggerDistance * 3)
        {
            Block3.SetActive(true);
        }
        if (distanceToCamera4 <= triggerDistance * 4)
        {
            Block4.SetActive(true);
        }
        if (distanceToCamera5 <= triggerDistance * 5)
        {
            Block5.SetActive(true);
        }
    }

  
    // 定期的にカメラの位置を確認し、オブジェクトをアクティブにする
    void Update()
    {
        ActivateObjectsIfCameraNear();
    }
}