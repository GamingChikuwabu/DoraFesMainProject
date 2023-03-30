using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // ロード済みのシーン名を格納するリスト
    private List<string> loadedScenes = new List<string>();
    // UIを格納
    GameObject canvas;

    private void Start()
    {
        // シーン間で共有するため、このオブジェクトを破棄しない
        // DontDestroyOnLoad(gameObject);

        // UIの習得
        canvas = GameObject.Find("SceneManager_Canvas");
    }

    // 指定されたシーンをロードするメソッド
    public void LoadScene(string sceneName)
    {
        if (!loadedScenes.Contains(sceneName))  // 既にロードされていない場合
        {
            // UIを非アクティブ化
            canvas.SetActive(false);

            // 指定されたシーンを追加でロード
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            loadedScenes.Add(sceneName);  // ロード済みリストに追加
        }
    }

    // 指定されたシーンをアンロードするメソッド
    public void UnloadScene(string sceneName)
    {
        if (loadedScenes.Contains(sceneName))  // ロードされている場合
        {
            // 指定されたシーンを非同期でアンロード
            SceneManager.UnloadSceneAsync(sceneName);
            loadedScenes.Remove(sceneName);  // ロード済みリストから削除
        }
    }
}