using System.Diagnostics;
using UnityEngine;
using UnityDebug = UnityEngine.Debug;

public class EnemyActivator : MonoBehaviour
{
    // �A�N�e�B�u�ɂ���I�u�W�F�N�g�̃^�O��
  
    [SerializeField] GameObject Block;
    [SerializeField] GameObject Block2;
    [SerializeField] GameObject Block3;

    public float triggerDistance = 150f; // �J���������̋����ȓ��ɋ߂Â�����I�u�W�F�N�g���A�N�e�B�u������

    private Transform cameraTransform; // �J������Transform�R���|�[�l���g
   

    // �J�����I�u�W�F�N�g
    private Camera mainCamera;
  // Start���\�b�h�ŃJ�����I�u�W�F�N�g���擾
    void Start()
    {
        mainCamera = Camera.main;

        // ���C���J������Transform�R���|�[�l���g���擾����
        cameraTransform = Camera.main.transform;
    }

    // �A�N�e�B�u�ɂ���I�u�W�F�N�g���擾����
    void ActivateObjectsIfCameraNear()
    {       
        float distanceToCamera = Block.transform.position.z - cameraTransform.position.z;
        float distanceToCamera2 = Block2.transform.position.z - cameraTransform.position.z;
        float distanceToCamera3 = Block3.transform.position.z - cameraTransform.position.z;

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
    }

  
    // ����I�ɃJ�����̈ʒu���m�F���A�I�u�W�F�N�g���A�N�e�B�u�ɂ���
    void Update()
    {
        ActivateObjectsIfCameraNear();
    }
}