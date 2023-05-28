using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPanel : MonoBehaviour
{
    private RectTransform panelRectTransform;

    //�������W���i�[����ϐ�
    private Vector2 initialPosition;

    //�X�s�[�h
    [Header("�X�s�[�h")]
    [SerializeField]private float speed;

    //�̎��ʔԍ�
    [Header("�̎��ʔԍ�")]
    [SerializeField] private int myNumber;

    //�p�l���̈ړ��J�n�t���O
    private bool startFlg; //�Q�[���J�n�t���O
    private bool feverFlg; //�t�B�[�o�[�^�C���t���O
    private bool isFever;
    private bool goalFlg;  //�S�[���t���O
    private bool isPanel; //��x�����\�������Ȃ�

    [Header("blackPanel")]
    [SerializeField]private  GameObject uiElement; // �������͓K�؂�UI�R���|�[�l���g�̌^

    //�v���C���[��GlobalStatusManager�X�N���v�g��isFever���擾����ϐ�
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        initialPosition = panelRectTransform.anchoredPosition;

        startFlg = false;
        feverFlg = false;
        goalFlg = false;

        //Player�̃X�N���v�g���擾����
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        isFever = GSM.IsFever;

        if(isPanel==false)
        {
            //�t�B�[�o�[�^�C���t���O�̎擾
            feverFlg = GSM.IsFever;

            //�S�[���t���O�̎擾
            //goalFlg=
        }

        if(isFever == false)
        {
            isPanel = false;
        }


        //�����ꂩ�̃t���O��true�Ȃ�
        if (startFlg)
        {
            if(myNumber ==1)
            {
                PanelMovement();
                uiElement.SetActive(true);
            }
           
        }
        else if (feverFlg)
        {
            if(myNumber == 2)
            {
                PanelMovement();
                uiElement.SetActive(true);
            }
        }
        else if (goalFlg)
        {
            if (myNumber == 3)
            {
                PanelMovement();
                uiElement.SetActive(true);
            }
        }
        else
        {
            uiElement.SetActive(false);
        }
        
    }

    //�p�l���̈ړ��֐�
    private void PanelMovement()
    {
        Vector2 newPosition = new Vector2(
            panelRectTransform.anchoredPosition.x - speed * Time.deltaTime,  // X�����̈ړ���
            panelRectTransform.anchoredPosition.y);                        // Y�����̈ړ��ʁi�ύX�Ȃ��j
        panelRectTransform.anchoredPosition = newPosition;

        //��ʊO�ɏo���珉���ʒu�ɖ߂�
        if(initialPosition.x - panelRectTransform.anchoredPosition.x > 3300)
        {
            panelRectTransform.anchoredPosition = initialPosition;
            isPanel = true;

            if(myNumber==1)
            {
                startFlg = false;

            }
        }
    }
}
