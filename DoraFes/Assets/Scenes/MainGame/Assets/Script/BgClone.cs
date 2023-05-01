using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgClone : MonoBehaviour
{
    void Start()
    {
        // ���g�̐e�I�u�W�F�N�g���擾
        GameObject parentObj = transform.parent.gameObject;
        float width = GetComponent<Transform>().localScale.x - 0.001f;

        // �E�Ɏ��g�𕡐�
        GameObject objRight = Instantiate(gameObject);
        objRight.transform.position = new(gameObject.transform.position.x + width, gameObject.transform.position.y, gameObject.transform.position.z);
        // �����ɑ������Ȃ��悤�X�N���v�g����菜��
        Destroy(objRight.GetComponent<BgClone>());
        // �e�I�u�W�F�N�g��ݒ�
        objRight.transform.SetParent(parentObj.transform, true);

        // ���Ɏ��g�𕡐�
        GameObject objLeft = Instantiate(gameObject);
        objLeft.transform.position = new(gameObject.transform.position.x - width, gameObject.transform.position.y, gameObject.transform.position.z);
        Destroy(objLeft.GetComponent<BgClone>());
        objLeft.transform.SetParent(parentObj.transform, true);
    }


    void Update()
    {
        
    }
}
