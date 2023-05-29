using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicController : MonoBehaviour
{
    [Header("�A�N�e�B�u�ύX����Image")]
    [SerializeField]private Image image;

    //�ړ��p
    private RectTransform panelRectTransform;

    //�X�s�[�h
    [Header("�X�s�[�h")]
    [SerializeField]private float speed;

    //�ړ������t���O
    private bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();

        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == false)
        {
            MovePanel();
        }

        if (Input.GetButtonDown("Comic"))
        {
            ActiveComic();
        }

        if (Input.GetKeyUp("Enter"))
        {
            ActiveComic();
        }
    }
    
    private void ActiveComic()
    {
        image.gameObject.SetActive(true);
    }

    private void MovePanel()
    {
        Vector3 newPosision = new Vector3(panelRectTransform.position.x, panelRectTransform.position.y,
            panelRectTransform.position.z + speed * Time.deltaTime);

        if(panelRectTransform.position.z>=0)
        {
            newPosision = new Vector3(panelRectTransform.position.x, panelRectTransform.position.y,0);

            isMove = true;
        }
    }
}
