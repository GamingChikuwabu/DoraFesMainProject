using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    [Header("リポップ座標")]
    [SerializeField] private float repopPosition;

    [Header("エンド座標")]
    [SerializeField] private float endPosition;

    [Header("スピード")]
    [SerializeField] private float speed = 10.0f;

    [Header("右に進むならチェック")]
    [SerializeField] private bool moveRight;

    private Rigidbody rb;

    private Vector3 initialPosition;  // 元の位置

    private float timeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        initialPosition = transform.position;
        initialPosition.x = repopPosition;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 移動方向を指定（例えば、右方向に移動）
        Vector3 movement = new Vector3(1f, 0f, 0f);


        // 移動方向に速度を乗算
        movement *= speed;

        if (moveRight)
        {
            // Rigidbodyのvelocityプロパティを設定
            rb.velocity = movement;
        }
        else
        {
            // Rigidbodyのvelocityプロパティを設定
            rb.velocity = -movement;
        }
        

        // 移動した距離が一定値を超えたら元の位置に戻す
        if (transform.position.x < endPosition)
        {
            //isMoving = false;
            Invoke("MoveBack", 0.1f);  // 1秒後に元の位置に戻す処理を呼び出す（任意の待ち時間）
        }

    }
    private void MoveBack()
    {
        // 元の位置に戻す
        transform.position = initialPosition;
       
    }
}
