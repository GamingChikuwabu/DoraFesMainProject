using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        // コントローラーの水平軸（左スティックまたは十字キー）の入力を取得
        horizontalInput = Input.GetAxis("Horizontal");

        // コントローラーの垂直軸（左スティックまたは十字キー）の入力を取得
        verticalInput = Input.GetAxis("Vertical");
    }

    public float GetHorizontalInput()
    {
        return horizontalInput;
    }

    public float GetVerticalInput()
    {
        return verticalInput;
    }
}

