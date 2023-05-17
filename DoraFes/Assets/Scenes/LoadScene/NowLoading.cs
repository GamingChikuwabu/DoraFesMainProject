using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowLoading : MonoBehaviour
{
    [Header("個体別番号")]
    [SerializeField] private int moveNum;

    //移動スピード
    private float moveSpeed = 100;

    //上昇値の上限
    private float upLimit = 20.0f;
    //番号の上限
    private int numLimit = 10;

    //上昇するオブジェクトの番号
    private static int upNum;
    //下降するオブジェクトの番号
    private static int downNum;

    // 初期位置
    private Vector3 startPosition ;

    // Start is called before the first frame update
    void Start()
    {
        upNum = 1; //上昇させる番号の初期値
        downNum = 0; //下降させる番号の初期値
        startPosition = transform.position; //初期位置をセットしておく

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //moveNumとupNumが一致したオブジェクトを上限させる
        if (moveNum == upNum)
        {
            //ここで上昇させる
            transform.Translate(0.0f, 0.0f, -moveSpeed * Time.deltaTime);

            //現在地と初期位置の差分が上昇値の上限を超えていたら
            if(transform.position.y - startPosition.y > upLimit)
            {
                upNum += 1;
                downNum += 1;
                if (upNum > numLimit)
                {
                    upNum = 1;
                }

                if (downNum > numLimit)
                {
                    downNum = 1;
                }
                
            }

        }

        //moveNumとdownNumが一致したオブジェクトを下降させる
        if (moveNum == downNum)
        {
            transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
        }
    }
}
