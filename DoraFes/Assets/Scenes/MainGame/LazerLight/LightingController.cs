using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    [Header("��̐F")]
    [SerializeField]private Color skyColor = Color.blue;
    [Header("�ԓ��̐F")]
    [SerializeField] private Color equatorColor = Color.gray;
    [Header("�n�ʂ̐F")]
    [SerializeField] private Color groundColor = Color.green;

    [Header("��̐F(�t�B�[�o�[��)")]
    [SerializeField] private Color feverSkykyColor = Color.blue;
    [Header("�ԓ��̐F(�t�B�[�o�[��)")]
    [SerializeField] private Color feverEquatorColor = Color.gray;
    [Header("�n�ʂ̐F(�t�B�[�o�[��)")]
    [SerializeField] private Color feverGroundColor = Color.green;

    //�t�B�[�o�[�����ǂ������擾����ϐ�
    private bool isFever;

    //�v���C���[��GlobalStatusManager�X�N���v�g��isFever���擾����ϐ�
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        isFever = false;

        //Player�̃X�N���v�g���擾����
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //�t�B�[�o�[�����ǂ������擾����
        isFever = GSM.IsFever;

        if(isFever)
        {
            // RenderSettings �̊��F��ݒ肷��
            RenderSettings.ambientSkyColor = feverSkykyColor;
            RenderSettings.ambientEquatorColor = feverEquatorColor;
            RenderSettings.ambientGroundColor = feverGroundColor;
        }
        else
        {
            // RenderSettings �̊��F��ݒ肷��
            RenderSettings.ambientSkyColor = skyColor;
            RenderSettings.ambientEquatorColor = equatorColor;
            RenderSettings.ambientGroundColor = groundColor;
        }
        
    }
}
