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
    private bool goalFlg;  //ゴールフラグ

    // Start is called before the first frame update
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        initialPosition = panelRectTransform.anchoredPosition;

        startFlg = true;
        feverFlg = false;
        goalFlg = false;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //フィーバータイムフラグの取得
        //startFlg=

        //ゴールフラグの取得
        //goalFlg=

        //いずれかのフラグがtrueなら
        if(startFlg)
        {
            if(myNumber ==1)
            {
                PanelMovement();
            }
        }
        else if (feverFlg)
        {
            if(myNumber == 2)
            {
                PanelMovement();
            }
        }
        else if (goalFlg)
        {
            if (myNumber == 3)
            {
                PanelMovement();
            }
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
            startFlg = false;
        }
    }
}
