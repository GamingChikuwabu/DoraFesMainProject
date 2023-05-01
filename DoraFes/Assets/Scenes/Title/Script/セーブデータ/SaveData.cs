/// <summary>
/// セーブデータを管理するスクリプタブルオブジェクトです。
/// セーブデータは、プレイヤーがゴールポイントに到達した際に更新されます。
/// </summary>

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData", order = 1)]
public class SaveData : ScriptableObject
{
    public string lastCompletedScene;

    public void SaveProgress(string sceneName)
    {
        lastCompletedScene = sceneName;
        PlayerPrefs.SetString("LastCompletedScene", lastCompletedScene);
        PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
        lastCompletedScene = PlayerPrefs.GetString("LastCompletedScene", "StageSelect");
    }

    public void ResetProgress()
    {
        lastCompletedScene = "StageSelect";
        PlayerPrefs.DeleteKey("LastCompletedScene");
        PlayerPrefs.Save();
    }

    public bool HasSaveData()
    {
        return PlayerPrefs.HasKey("LastCompletedScene");
    }

}
