using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewLoadScene : MonoBehaviour
{
    public float loadingTime = 5f; // ロード画面を表示する時間

    private void Start()
    {
        // ロード画面を表示する
        SceneManager.LoadSceneAsync("LoadScene", LoadSceneMode.Additive);
        // 次のシーンに遷移するコルーチンを開始する
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        // 指定した時間だけロード画面を表示する
        yield return new WaitForSeconds(loadingTime);

        // ロード画面を削除する
        SceneManager.UnloadSceneAsync("LoadScene");

        // 次のシーンに遷移する
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes in build settings.");
        }
    }
}

