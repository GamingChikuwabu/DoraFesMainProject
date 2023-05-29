using UnityEngine;

public class Roller_Action : MonoBehaviour
{
    public float speed = 5f;         // 移動速度
    public float amplitude = 2f;     // 蛇行の振幅
    public float frequency = 1f;     // 蛇行の周波数

    private float startTime;         // 開始時間

    private void Start()
    {
        // 開始時間を記録
        startTime = Time.time;
    }

    private void Update()
    {
        // 現在の経過時間を取得
        float elapsedTime = Time.time - startTime;

        // X座標を三角関数で計算
        float xPos = Mathf.Sin(elapsedTime * frequency) * amplitude;

        // オブジェクトを蛇行しながら前進させる
        transform.Translate(new Vector3(xPos, 0f, speed) * Time.deltaTime);
    }
}