using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    public float moveDistance = 10f;  // 移動する距離
    public float moveSpeed = 5f;  // 移動速度

    private Vector3 initialPosition;  // 元の位置
    private bool isMoving;  // 移動中かどうかのフラグ
    private float movedDistance = 0f;  // 移動した距離の累計

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            // x方向に移動する
            float moveStep = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveStep);

            // 移動した距離を更新
            movedDistance += Mathf.Abs(moveStep);
            

            // 移動した距離が一定値を超えたら元の位置に戻す
            if (movedDistance >= moveDistance)
            {
                //isMoving = false;
                Invoke("MoveBack", 0.1f);  // 1秒後に元の位置に戻す処理を呼び出す（任意の待ち時間）
            }
        }
    }
    private void MoveBack()
    {
        // 元の位置に戻す
        transform.position = initialPosition;
        movedDistance = 0f;  // 移動した距離をリセット
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
