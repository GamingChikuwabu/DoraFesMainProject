using System.Diagnostics;
using UnityEngine;
using UnityDebug = UnityEngine.Debug;

public class ObjectActivator : MonoBehaviour
{
    // アクティブにするオブジェクトのタグ名
  
    [SerializeField] GameObject tex;
    public float triggerDistance = 10f; // カメラがこの距離以内に近づいたらオブジェクトをアクティブ化する
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
    {        //// アクティブにするオブジェクトを取得


       
        float distanceToCamera = tex.transform.position.z - cameraTransform.position.z;
        if (distanceToCamera <= triggerDistance)
        {
            tex.SetActive(true);
        }
      
    }

  
    // 定期的にカメラの位置を確認し、オブジェクトをアクティブにする
    void Update()
    {
        ActivateObjectsIfCameraNear();
    }
}