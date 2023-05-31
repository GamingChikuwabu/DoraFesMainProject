using System;
using UnityEngine;

//summary
//　ScritableObjectを使用したセーブシステム
//  
//　他のスクリプトで使う場合は、
//　　public SaveData saveData;
//    このように宣言して、一度コンパイルしてから
//    title/script/savedata/scritableobjectをアタッチ
//    その後、
//
//  if (saveData.IsSceneCompleted("1-1"))
//  {
//        // クリアしているときの処理
//  }
//  if(saveData.IsSceneCompleted("1-2"))
//  {
//        // クリアしているときの処理
//  }
//  if(saveData.IsSceneCompleted("1-3"))
//      同上
//
//  というように、クリアしているシーンを判定して、
//  そのシーンのクリアしているときの処理を書く
//
//summary

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData", order = 1)]
public class SaveData : ScriptableObject
{
    // 最後にクリアしたシーンの名前を保存
    public string lastCompletedScene;

    // 指定されたシーンの進捗を保存
    public void SaveProgress(string sceneName)
    {
        // シーンの名前をlastCompletedSceneとPlayerPrefsに保存
        lastCompletedScene = sceneName;
        PlayerPrefs.SetString("LastCompletedScene", lastCompletedScene);
        // シーンが5-4の場合、保存する値を"5-3"とする
        if (sceneName == "5-4")
        {
            sceneName = "5-3";
        }
        PlayerPrefs.Save();  // PlayerPrefsにデータを保存
    }

    // 保存した進捗を読み込む
    public void LoadProgress()
    {
        // PlayerPrefsからlastCompletedSceneを読み込み、存在しなければ1-1をデフォルト値とする
        lastCompletedScene = PlayerPrefs.GetString("LastCompletedScene", "1-1");
    }

    // 進捗をリセット
    public void ResetProgress()
    {
        // lastCompletedSceneを1-1にリセットし、PlayerPrefsからLastCompletedSceneのデータを削除
        lastCompletedScene = "1-1";
        PlayerPrefs.DeleteKey("LastCompletedScene");
        PlayerPrefs.Save();  // PlayerPrefsにデータを保存
    }

    // セーブデータが存在するかどうかを返す
    public bool HasSaveData()
    {
        //LastCompletedSceneというキーのデータがPlayerPrefsに存在するか確認
        return PlayerPrefs.HasKey("LastCompletedScene");
    }

    // 指定したシーンが既に完了しているかを判断する
    public bool IsSceneCompleted(string sceneName)
    {
        // 最後に完了したシーンの番号が指定されたシーンの番号以上であれば、そのシーンは完了していると判断
        string[] lastCompletedSceneSplit = lastCompletedScene.Split('-');
        int lastCompletedSceneNumber = int.Parse(lastCompletedSceneSplit[0]) * 100 + int.Parse(lastCompletedSceneSplit[1]);

        string[] sceneNameSplit = sceneName.Split('-');
        int sceneNumber = int.Parse(sceneNameSplit[0]) * 100 + int.Parse(sceneNameSplit[1]);

        return sceneNumber <= lastCompletedSceneNumber;
    }
}
