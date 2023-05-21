using UnityEngine;

public class Swaying : MonoBehaviour
{
    // 選択中であるかどうか
    private bool isSelected = false;

    // 初期位置
    private Vector3 initialPosition;

    

    // 上下移動の速度
    [Header("移動速度")]
    [SerializeField] private float speed = 1.0f;

    // 上下移動の幅
    [Header("可動域")]
    [SerializeField] private float amplitude = 0.5f;

    void Start()
    {
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
            // sin関数を使って上下に揺らす
            float newPosition = Mathf.Sin(Time.time * speed) * amplitude + initialPosition.z;
            transform.position = new Vector3(initialPosition.x, initialPosition.y, newPosition);
        }
        // 選択されていない場合
        else
        {
            // 初期位置に戻す
            transform.position = initialPosition;
        }
    }
}
