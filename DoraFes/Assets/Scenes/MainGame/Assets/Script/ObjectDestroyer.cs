using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public string targetTag = "Target"; // �����Ώۂ̃^�O

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            // �w��̃^�O�ɐG�ꂽ��I�u�W�F�N�g��j������
            Destroy(other.gameObject);
        }
    }
}