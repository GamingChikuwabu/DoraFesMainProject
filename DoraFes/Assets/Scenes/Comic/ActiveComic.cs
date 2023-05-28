using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetChildrenActive(false); // �q�I�u�W�F�N�g�����ׂăA�N�e�B�u�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        
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
