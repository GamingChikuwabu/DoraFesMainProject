using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMove : MonoBehaviour
{
    private RectTransform panelRectTransform;

    //初期座標を格納する変数
    private Vector2 initialPosition;

    //スピード
    [Header("スピード")]
    [SerializeField] private float speed;

    [Header("blackPanel")]
    [SerializeField] private GameObject uiElement;

    private bool isPanel;
    private bool isFever;

    //プレイヤーのGlobalStatusManagerスクリプトのisFeverを取得する変数
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        //Playerのスクリプトを取得する
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
            panelRectTransform.anchoredPosition.x - speed * Time.deltaTime,  // X方向の移動量
            panelRectTransform.anchoredPosition.y);                        // Y方向の移動量（変更なし）
        panelRectTransform.anchoredPosition = newPosition;

        //画面外に出たら初期位置に戻す
        if (initialPosition.x - panelRectTransform.anchoredPosition.x > 3300)
        {
            panelRectTransform.anchoredPosition = initialPosition;

            isPanel = true;
            uiElement.SetActive(false);

        }
    }
}
