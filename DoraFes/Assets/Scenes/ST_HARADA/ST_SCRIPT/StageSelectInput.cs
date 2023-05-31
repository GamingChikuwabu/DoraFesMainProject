using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectInput : MonoBehaviour
{
    public enum IsInputBottom
    {
        NONE,       // 入力なし
        STICK_H_P,  // スティック横方向（正）
        STICK_H_N,  // スティック横方向（負）
        STICK_V_P,  // スティック縦方向（正）
        STICK_V_N,  // スティック縦方向（負）
        A,          // A
        B,          // B
        L,          // L
        R,          // R
    }

    // 現フレームで入力されたボタンを格納
    [System.NonSerialized] public IsInputBottom isBottom = IsInputBottom.NONE;
    // 現フレームでスティックの入力があったか判別する
    private bool isInputStick = false;

    [Header("入力の間隔")]
    public float interval = 0.3f;
    [System.NonSerialized] public float intervalCount = 0f;   // 入力されてからの経過時間

    // 入力情報の更新
    public void CheakInput()
    {
        // ボタン入力状況を初期化
        isBottom = IsInputBottom.NONE;

        // 最後に入力されてから規定時間以下
        if (Time.time - intervalCount < interval) return;

        // キーの入力状況を格納
        CheakInputKey();

        // コントローラーの入力状況を更新
        CheakInputStick();  // スティックの入力をチェック

        // 優先順でボタンの入力情報を格納
        if (isInputStick) {}
        else if (Input.GetKey("joystick button 0")) isBottom = IsInputBottom.A;
        else if (Input.GetKey("joystick button 1")) isBottom = IsInputBottom.B;
        else if (Input.GetKey("joystick button 4")) isBottom = IsInputBottom.L;
        else if (Input.GetKey("joystick button 5")) isBottom = IsInputBottom.R;

        // 入力された時刻を格納
        if (isBottom != IsInputBottom.NONE)
        {
            intervalCount = Time.time;
        }
    }

    // スティックの入力有無をチェックする関数
    void CheakInputStick()
    {
        // 入力状況を初期化
        isInputStick = false;

        float horizontalInput;  // 横方向の入力
        float verticalInput;    // 縦方向の入力
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // 現フレームで入力されたか？
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            isInputStick = true;

            // 横方向への傾きが大きい
            if (Mathf.Abs(horizontalInput) - Mathf.Abs(verticalInput) >= 0)
            {
                // 正方向に倒されているのか？
                if (horizontalInput >= 0) isBottom = IsInputBottom.STICK_H_P;
                else isBottom = IsInputBottom.STICK_H_N;
            }
            // 縦方向への傾きが大きい
            else
            {
                // 正方向に倒されているのか？
                if (verticalInput >= 0) isBottom = IsInputBottom.STICK_V_P;
                else isBottom = IsInputBottom.STICK_V_N;
            }
        }
    }

    // キーボードの入力処理
    void CheakInputKey()
    {
        if (Input.GetKeyDown(KeyCode.D)) isBottom = IsInputBottom.STICK_H_P;
        else if (Input.GetKeyDown(KeyCode.A)) isBottom = IsInputBottom.STICK_H_N;
        else if (Input.GetKeyDown(KeyCode.W)) isBottom = IsInputBottom.STICK_V_P;
        else if (Input.GetKeyDown(KeyCode.S)) isBottom = IsInputBottom.STICK_V_N;
        else if (Input.GetKeyDown(KeyCode.Return)) isBottom = IsInputBottom.A;
        else if (Input.GetKeyDown(KeyCode.B)) isBottom = IsInputBottom.B;
        else if (Input.GetKeyDown(KeyCode.Q)) isBottom = IsInputBottom.L;
        else if (Input.GetKeyDown(KeyCode.E)) isBottom = IsInputBottom.R;
    }
}