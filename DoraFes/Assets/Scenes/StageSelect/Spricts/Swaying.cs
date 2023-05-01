using UnityEngine;

public class Swaying : MonoBehaviour
{
    // 選択中であるかどうか
    private bool isSelected = false;

    // 揺れる位置
    private float movePos;

    // 初期位置
    private Vector3 initialPosition;

    void Start()
    {
        // y座標を代入
        movePos = transform.position.z;

        // 初期位置を代入
        initialPosition = transform.position;   
    }

    void Update()
    {
        // StageSelectスプリクトから取得し代入
        StageSelect.STAGENAME stage = StageSelect.StageName;

        // stage変数とオブジェクトの名前が一致する場合trueに
        if (gameObject.name == stage.ToString())
        {
            isSelected = true;
        }
        // 一致しない場合
        else
        {
            isSelected = false;
        }

        // 選択されている場合
        if (isSelected)
        {
            //上下に揺らす
            transform.position = new Vector3(transform.position.x, transform.position.y, movePos + Mathf.PingPong(Time.time / 3, 0.5f));

        }
        // 選択されていない場合
        else
        {
            // 初期位置に戻す
            transform.position = initialPosition;

        }
    }
}