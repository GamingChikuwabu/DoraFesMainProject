using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コインがプレイヤーに吸い込まれるスクリプト
public class CoinAbsorption : MonoBehaviour
{

    //カメラのスピードを取得するオブジェクト
    private GameObject landmark;

    // 移動先の対象
    private GameObject Player;
    private GlobalStatusManager GSM;

    //吸い込みスピード
    private float speed = 80.0f;

    //吸い込み範囲
    private float range = 40.0f;

    [Header("カメラのスピードに加算する値")]
    [SerializeField] private float addspeed = 10.0f;

    // コインとプレイヤーの距離を格納する変数
    private float distance;

    private Vector3 targetPosition;

    private void Start()
    {
        //目標オブジェクトの取得
        Player = GameObject.FindGameObjectWithTag("MainPlayer");
        GSM = Player.GetComponent<GlobalStatusManager>();
    }

    void Update()
    {
        if (GSM.IsFever)
        {
            // コインとプレイヤーの距離
            distance = Player.transform.position.z - transform.position.z;

            // 絶対値を取る
            distance = Mathf.Abs(distance);

            // コインとプレイヤーの距離が吸い込み範囲より短かったら
            if (distance < range)
            {
                //speed = Mathf.Max(speed, LM.LandMarkSpeed + addspeed);

                // コインの移動先をプレイヤーの位置に設定する
                targetPosition = Player.transform.position;

                // 吸い込まれるスピード
                float step = speed * Time.deltaTime;

                // Vector3.MoveTowards (基準となる開始座標, 到達したい座標, 移動速度)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            }
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //}

}
