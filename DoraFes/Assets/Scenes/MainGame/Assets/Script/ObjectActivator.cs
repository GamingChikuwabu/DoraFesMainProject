using System.Diagnostics;
using UnityEngine;
using UnityDebug = UnityEngine.Debug;

public class ObjectActivator : MonoBehaviour
{
    // �A�N�e�B�u�ɂ���I�u�W�F�N�g�̃^�O��
  
    [SerializeField] GameObject tex;
    public float triggerDistance = 10f; // �J���������̋����ȓ��ɋ߂Â�����I�u�W�F�N�g���A�N�e�B�u������
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
    {        //// �A�N�e�B�u�ɂ���I�u�W�F�N�g���擾


       
        float distanceToCamera = tex.transform.position.z - cameraTransform.position.z;
        if (distanceToCamera <= triggerDistance)
        {
            tex.SetActive(true);
        }
      
    }

  
    // ����I�ɃJ�����̈ʒu���m�F���A�I�u�W�F�N�g���A�N�e�B�u�ɂ���
    void Update()
    {
        ActivateObjectsIfCameraNear();
    }
}