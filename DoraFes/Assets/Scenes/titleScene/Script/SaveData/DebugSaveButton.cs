using UnityEngine;
using UnityEngine.UI;

//summary
//
//UIボタン用のスクリプト
//UIButtonを用意
//このスクリプトをアタッチ
//title/script/savedata/scritableobjectをアタッチ
//インスペクタービューのOnclickにこれをアタッチしたオブジェクトをアタッチ
//DebugSaveButton.SaveDebugを選択
//ゲーム本編でButtonを押すと、5-5がクリアされた状態になる
//
//summary

public class DebugSaveButton : MonoBehaviour
{
    public SaveData saveData; // 保存データへの参照

    void Start()
    {
        // ボタンのクリックイベントにリスナーを追加
        GetComponent<Button>().onClick.AddListener(SaveDebug);
    }

    // 5-5を保存するデバッグ用関数
    public void SaveDebug()
    {
        saveData.SaveProgress("5-5");
        Debug.Log("Saved 5-5 for debugging purposes");
    }
}
