using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildActive : MonoBehaviour
{
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

        SetChildrenActive(false); // �q�I�u�W�F�N�g�����ׂĔ�A�N�e�B�u�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        //�t�B�[�o�[�����ǂ������i�[����
        isFever = GSM.IsFever;

        if(isFever)
        {
            SetChildrenActive(true); // �q�I�u�W�F�N�g�����ׂăA�N�e�B�u�ɂ���
        }
        else
        {
            SetChildrenActive(false); // �q�I�u�W�F�N�g�����ׂĔ�A�N�e�B�u�ɂ���
        }
    }

    private void SetChildrenActive(bool active)
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(active);
        }
    }
}
