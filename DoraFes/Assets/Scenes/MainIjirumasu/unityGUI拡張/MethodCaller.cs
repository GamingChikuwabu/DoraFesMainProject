using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

// <summary>
// UnityEditor画面でメソッドを呼び出すクラス
// 使い方：
// このスクリプトを処理を確認したいオブジェクトにアタッチ
// アタッチしたオブジェクトのInspectorで、callに呼び出したいメソッドをドラッグ＆ドロップ
// </summary>

public class MethodCaller : MonoBehaviour
{
	public UnityEvent call;

	#if !UNITY_EDITOR
	void Awake()
	{
		Destroy( this );
	}
	#endif
}