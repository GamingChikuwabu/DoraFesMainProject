using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コインがプレイヤーに吸い込まれるスクリプト
public class CoinAbsorption : MonoBehaviour
{
    [Header("移動先の対象")]
    [SerializeField] private GameObject Player;

    [Header("吸い込みスピード")]
    [SerializeField] private float speed = 0.0f;

    [Header("吸い込み範囲")]
    [SerializeField] private float range = 0.0f;

    // コインとプレイヤーの距離を格納する変数
    private float distance;

    private Vector3 targetPosition;

    void Update()
    {
        // コインとプレイヤーの距離
        distance = Player.transform.position.z - transform.position.z;

        // 絶対値を取る
        distance = Mathf.Abs(distance);

        // コインとプレイヤーの距離が吸い込み範囲より短かったら
        if (distance < range)
        {
            // コインの移動先をプレイヤーの位置に設定する
            targetPosition = Player.transform.position;

            // 吸い込まれるスピード
            float step = speed * Time.deltaTime;

            // Vector3.MoveTowards (基準となる開始座標, 到達したい座標, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        }
    }
}
