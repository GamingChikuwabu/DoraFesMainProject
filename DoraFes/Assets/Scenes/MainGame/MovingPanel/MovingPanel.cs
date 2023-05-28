using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPanel : MonoBehaviour
{
    private RectTransform panelRectTransform;

    //初期座標を格納する変数
    private Vector2 initialPosition;

    //スピード
    [Header("スピード")]
    [SerializeField]private float speed;

    //個体識別番号
    [Header("個体識別番号")]
    [SerializeField] private int myNumber;

    //パネルの移動開始フラグ
    private bool startFlg; //ゲーム開始フラグ
    private bool feverFlg; //フィーバータイムフラグ
    private bool isFever;
    private bool goalFlg;  //ゴールフラグ
    private bool isPanel; //一度しか表示させない

    [Header("blackPanel")]
    [SerializeField]private  GameObject uiElement; // もしくは適切なUIコンポーネントの型

    //プレイヤーのGlobalStatusManagerスクリプトのisFeverを取得する変数
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

        //Playerのスクリプトを取得する
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        isFever = GSM.IsFever;

        if(isPanel==false)
        {
            //フィーバータイムフラグの取得
            feverFlg = GSM.IsFever;

            //ゴールフラグの取得
            //goalFlg=
        }

        if(isFever == false)
        {
            isPanel = false;
        }


        //いずれかのフラグがtrueなら
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

    //パネルの移動関数
    private void PanelMovement()
    {
        Vector2 newPosition = new Vector2(
            panelRectTransform.anchoredPosition.x - speed * Time.deltaTime,  // X方向の移動量
            panelRectTransform.anchoredPosition.y);                        // Y方向の移動量（変更なし）
        panelRectTransform.anchoredPosition = newPosition;

        //画面外に出たら初期位置に戻す
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
