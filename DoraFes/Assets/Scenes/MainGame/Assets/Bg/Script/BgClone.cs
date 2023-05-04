using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgClone : MonoBehaviour
{
    void Start()
    {
        // 自身の親オブジェクトを取得
        GameObject parentObj = transform.parent.gameObject;
        float width = GetComponent<Transform>().localScale.x - 0.001f;

        // 右に自身を複製
        GameObject objRight = Instantiate(gameObject);
        objRight.transform.position = new(gameObject.transform.localPosition.x + width, 
            gameObject.transform.localPosition.y, 
            gameObject.transform.localPosition.z);
        // 無限に増加しないようスクリプトを取り除く
        Destroy(objRight.GetComponent<BgClone>());
        // 親オブジェクトを設定
        objRight.transform.SetParent(parentObj.transform, true);

        // 左に自身を複製
        GameObject objLeft = Instantiate(gameObject);
        objLeft.transform.position = new(gameObject.transform.localPosition.x - width, 
            gameObject.transform.localPosition.y, 
            gameObject.transform.localPosition.z);
        Destroy(objLeft.GetComponent<BgClone>());
        objLeft.transform.SetParent(parentObj.transform, true);
    }
}
