using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour
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
    private bool isGoal;

    //�S�[���t���O�擾
    private GameObject GoalObject;
    private CameraSwitcher CS;

    // Start is called before the first frame update
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        initialPosition = panelRectTransform.anchoredPosition;

        uiElement.SetActive(false);

        isPanel = false;
        isGoal = false;

        //�S�[���t���O�擾
        GoalObject = GameObject.Find("goal");
        CS = GoalObject.GetComponent<CameraSwitcher>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�S�[���t���O�擾
        isGoal = CS.goalfg;

        if(isPanel == false)
        {
            if (isGoal)
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
