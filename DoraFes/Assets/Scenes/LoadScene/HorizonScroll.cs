using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizonScroll : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    [Header("�X�N���[���X�s�[�h")]
    [SerializeField]private float ScrollSpeed = 1.0f;

    //�͈͊O�ɂ������Ƃ��Ɉړ�������W
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = gameObject.transform.position;
        newPosition.x = -2081;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //�X�N���[��������
        transform.Translate(-ScrollSpeed + Time.deltaTime, 0.0f, 0.0f);

        if(transform.position.x>=2118)
        {
            gameObject.transform.position = newPosition;
        }
    }
}
