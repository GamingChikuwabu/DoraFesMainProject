using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageSelectInput;

public class SelectWorld : MonoBehaviour
{
    [SerializeField] Vector3[] ConstPos = new Vector3[5];

    private StageSelectInput stInput;

    int nowSelectWorld = 0;
    int nextSelectWorld = 0;

    void Start()
    {
        // 初期座標を代入
        transform.position = ConstPos[nowSelectWorld];
        // コンポーネント取得
        stInput = gameObject.GetComponent<StageSelectInput>();
    }

    void Update()
    {
        // 入力情報を更新
        stInput.CheakInput();

        // 入力されているボタンによって分岐
        switch (stInput.isBottom)
        {
            // 横方向（正）の処理
            case IsInputBottom.STICK_H_P:
                nowSelectWorld += 1;
                break;
            // 横方向（負）の処理
            case IsInputBottom.STICK_H_N:
                nowSelectWorld -= 1;
                break;
        }

        // ワールド選択で端っこに行った場合
        if (nowSelectWorld < 0) nowSelectWorld = 4;
        else if (nowSelectWorld > 4) nowSelectWorld = 0;

        transform.position = ConstPos[nowSelectWorld];


        if (nowSelectWorld != nextSelectWorld)
        {

        }
       
    }
}
