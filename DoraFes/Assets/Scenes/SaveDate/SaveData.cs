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
        lastCompletedScene = PlayerPrefs.GetString("LastCompletedScene", "1-1");
    }

    public void ResetProgress()
    {
        lastCompletedScene = "1-1";
        PlayerPrefs.DeleteKey("LastCompletedScene");
        PlayerPrefs.Save();
    }

    public bool HasSaveData()
    {
        return PlayerPrefs.HasKey("LastCompletedScene");
    }

   public string GetString()
    {

        return lastCompletedScene;
    }
}

//使用方法
//以下の2行を使いたいスクリプトで記述してください。
//データの型はstringです。
//
//string lastCompletedScene = saveData.LastCompletedScene;
//bool hasSaveData = saveData.HasSaveData();
//
//

/*

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData", order = 1)]
public class SaveData : ScriptableObject
{
    private const string sceneKey = "LastCompletedScene";

    public string LastCompletedScene
    {
        get
        {
            return PlayerPrefs.GetString(sceneKey, "1-1");
        }
    }

    public void SaveProgress(string sceneName)
    {
        PlayerPrefs.SetString(sceneKey, sceneName);
        PlayerPrefs.Save();
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.Save();
    }

    public bool HasSaveData()
    {
        return PlayerPrefs.HasKey(sceneKey);
    }
}


*/