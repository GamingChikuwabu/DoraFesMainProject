using UnityEngine;

public class Camerades : MonoBehaviour
{
    // �����I�u�W�F�N�g�̃^�O��
    public string destroyableTag = "Destroyable";

    // �J�����I�u�W�F�N�g
    private Camera mainCamera;

    // Start���\�b�h�ŃJ�����I�u�W�F�N�g���擾
    void Start()
    {
        mainCamera = Camera.main;
    }

    // �J�������ʂ�߂����I�u�W�F�N�g���폜����
    void DestroyObjectsIfCameraPassed()
    {
        // �����I�u�W�F�N�g���擾
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(destroyableTag);

        // �J�������ʂ�߂����I�u�W�F�N�g���폜
        foreach (GameObject obj in objectsToDestroy)
        {
            if (mainCamera.transform.position.z > obj.transform.position.z)
            {
                Destroy(obj);
            }
        }
    }

    // ����I�ɃJ�����̈ʒu���m�F���A�I�u�W�F�N�g���폜����
    void Update()
    {
        DestroyObjectsIfCameraPassed();
    }
}