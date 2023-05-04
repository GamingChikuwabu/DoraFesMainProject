using UnityEngine;

public class Camerades : MonoBehaviour
{
    // 消すオブジェクトのタグ名
    public string destroyableTag = "Destroyable";

    // カメラオブジェクト
    private Camera mainCamera;

    // Startメソッドでカメラオブジェクトを取得
    void Start()
    {
        mainCamera = Camera.main;
    }

    // カメラが通り過ぎたオブジェクトを削除する
    void DestroyObjectsIfCameraPassed()
    {
        // 消すオブジェクトを取得
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(destroyableTag);

        // カメラが通り過ぎたオブジェクトを削除
        foreach (GameObject obj in objectsToDestroy)
        {
            if (mainCamera.transform.position.z > obj.transform.position.z)
            {
                Destroy(obj);
            }
        }
    }

    // 定期的にカメラの位置を確認し、オブジェクトを削除する
    void Update()
    {
        DestroyObjectsIfCameraPassed();
    }
}