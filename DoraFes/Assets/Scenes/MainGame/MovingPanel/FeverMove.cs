using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMove : MonoBehaviour
{
    private RectTransform panelRectTransform;

    //�������W���i�[����ϐ�
    private Vector2 initialPosition;

    //�X�s�[�h
    [Header("�X�s�[�h")]
    [SerializeField] private float speed;

    [Header("blackPanel")]
    [SerializeField] private GameObject uiElement;

    private bool isPanel;
    private bool isFever;

    //�v���C���[��GlobalStatusManager�X�N���v�g��isFever���擾����ϐ�
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        //Player�̃X�N���v�g���擾����
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();

        panelRectTransform = GetComponent<RectTransform>();
        initialPosition = panelRectTransform.anchoredPosition;

        uiElement.SetActive(false);

        isPanel = false;
        isFever = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isFever = GSM.IsFever;

        if (isFever == false)
        {
            isPanel = false;
        }

        if (isPanel == false)
        {
            if (isFever)
            {
                uiElement.SetActive(true);
                PanelMovement();
            }
        }
        
    }

    private void PanelMovement()
    {
        Vector2 newPosition = new Vector2(
            panelRectTransform.anchoredPosition.x - speed * Time.deltaTime,  // X�����̈ړ���
            panelRectTransform.anchoredPosition.y);                        // Y�����̈ړ��ʁi�ύX�Ȃ��j
        panelRectTransform.anchoredPosition = newPosition;

        //��ʊO�ɏo���珉���ʒu�ɖ߂�
        if (initialPosition.x - panelRectTransform.anchoredPosition.x > 3300)
        {
            panelRectTransform.anchoredPosition = initialPosition;

            isPanel = true;
            uiElement.SetActive(false);

        }
    }
}
