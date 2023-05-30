using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class ButtonSelect : MonoBehaviour
{
	Button Retry;
	Button Return;

	//コントローラーの取得
	private GameObject ChangeSceneObject;
	private ControllerInput CI;

	//リトライボタンが選択されているかどうか
	private bool isRetryBotton;

	void Start()
	{
		// ボタンコンポーネントの取得
		Retry = GameObject.Find("Retry").GetComponent<Button>();
		Return = GameObject.Find("Return").GetComponent<Button>();

		ChangeSceneObject = GameObject.Find("ChangeScene");
		CI = ChangeSceneObject.GetComponent<ControllerInput>();

		// 最初に選択状態にしたいボタンの設定
		Retry.Select();
		isRetryBotton = true;
	}

    private void Update()
    {
        if (isRetryBotton == true)
        {
			//Retry.colors()
			if (CI.GetVerticalInput() > 0.0f)
			{
				isRetryBotton = false;
				Return.Select();
			}
		}
        else
        {
			if (CI.GetVerticalInput() < 0.0f)
			{
				isRetryBotton = true;
				Retry.Select();
			}
		}
        
    }


}
