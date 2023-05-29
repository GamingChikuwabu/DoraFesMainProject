using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildActive : MonoBehaviour
{
    private bool isFever;

    //プレイヤーのGlobalStatusManagerスクリプトのisFeverを取得する変数
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        isFever = false;

        //Playerのスクリプトを取得する
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();

        SetChildrenActive(false); // 子オブジェクトをすべて非アクティブにする
    }

    // Update is called once per frame
    void Update()
    {
        //フィーバー中かどうかを格納する
        isFever = GSM.IsFever;

        if(isFever)
        {
            SetChildrenActive(true); // 子オブジェクトをすべてアクティブにする
        }
        else
        {
            SetChildrenActive(false); // 子オブジェクトをすべて非アクティブにする
        }
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
