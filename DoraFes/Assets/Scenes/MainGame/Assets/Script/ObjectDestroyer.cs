using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public string targetTag = "Target"; // 消す対象のタグ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            // 指定のタグに触れたらオブジェクトを破棄する
            Destroy(other.gameObject);
        }
    }
}