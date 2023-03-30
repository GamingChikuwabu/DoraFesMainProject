using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLoader : MonoBehaviour
{
    private static bool Loaded { get; set; }

    void Awake()
    {
        if (Loaded) return;

        Loaded = true;
        SceneManager.LoadScene("SceneManager");
    }

    private void Update()
    {
        // エスケイプキーが押されたら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // アプリケーションを終了する
            Application.Quit();
        }
    }
}