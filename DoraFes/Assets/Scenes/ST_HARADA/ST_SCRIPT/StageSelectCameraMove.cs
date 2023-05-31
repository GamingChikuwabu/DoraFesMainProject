using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectCameraMove : MonoBehaviour
{
    // 開始アニメーションで使用する変数
    public float animTime01 = 4;    // 第１アニメーションにかける時間
    public float animTime02 = 1;    // 第２アニメーションにかける時間
    public float animTime03 = 1;    // 第２アニメーションにかける時間

    bool isAnim01 = true;       // 第１アニメーション中かどうか
    bool isAnim02 = true;       // 第２アニメーション中かどうか
    bool isAnim03 = true;       // 第２アニメーション中かどうか

    float HankeiZ;              // 第１アニメーションで使用する回転半径
    


    float count;    // タイム

    float startPosYAnim02;      // 第２アニメーションで使用する回転半径
    float endPosYAnim02 = 67;   // 第２アニメーションでの終了位置Y


    public GameObject cursol;
    public GameObject[] deleteObj;

    public Image fadeUI;
    public float fadeSpeed;

    void Start()
    {
        startPosYAnim02 = transform.position.y;

        HankeiZ = transform.position.z;
        count = Time.time;
    }

    void Update()
    {
        if (fadeUI.color.a > 0)
        {
            Color color = fadeUI.color;
            color.a -= Time.deltaTime * fadeSpeed;
            fadeUI.color = color;
        }
        else
        {
            Color color = fadeUI.color;
            color.a = 0;
            fadeUI.color = color;
        }



        // 第一アニメーション
        if (isAnim01)
        {
            // カメラ座標移動
            transform.position = new((HankeiZ + 10) * -Mathf.Sin((Time.time - count) / animTime01 * 180 * Mathf.Deg2Rad),
                transform.position.y,
                HankeiZ * Mathf.Cos((Time.time - count) / animTime01 * 180 * Mathf.Deg2Rad));
            // カメラ回転
            transform.eulerAngles = new(transform.eulerAngles.x,
                90 * Mathf.Cos((Time.time - count) / animTime01 * 180 * Mathf.Deg2Rad) + 90,
                transform.eulerAngles.z);

            if (Time.time - count > animTime01)
            {
                // カメラ座標移動
                transform.position = new((HankeiZ + 10) * -Mathf.Sin(180 * Mathf.Deg2Rad),
                    transform.position.y,
                    HankeiZ * Mathf.Cos(180 * Mathf.Deg2Rad));
                // カメラ回転
                transform.eulerAngles = new(transform.eulerAngles.x,
                    90 * Mathf.Cos(180 * Mathf.Deg2Rad) + 90,
                    transform.eulerAngles.z);

                count = Time.time;
                isAnim01 = false;
            }
        }
        else if (isAnim02)
        {
            // 現在の経過時間
            float elapsedTime = Time.time - count;

            // 経過時間を遷移時間で割り、0から1までの割合に変換
            float t = Mathf.Clamp01(elapsedTime / animTime02);

            // 変化前の値と変化後の値をtの割合で線形補間しライトの強さに代入
            transform.position = new(transform.position.x,
                Mathf.Lerp(startPosYAnim02, endPosYAnim02, t),
                transform.position.z);

            // 規定時間が経過した？
            if (t == 1)
            {
                transform.position = new(0,
                transform.position.y,
                transform.position.z);

                count = Time.time;
                isAnim02 = false;
            }
        }
        else if (isAnim03)
        {
            if (Time.time - count > animTime03)
            {
                for (int i = 0; deleteObj.Length > i; i++)
                {
                    Destroy(deleteObj[i]);
                }
                // カーソルをアクティブ化
                cursol.SetActive(true);
                // このスクリプトを取り除く
                Destroy(GetComponent<StageSelectCameraMove>());
            }
        }
    }
}
