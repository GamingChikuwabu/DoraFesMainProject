using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLoader : MonoBehaviour
{
    private static bool Loaded { get; set; }
    static SceneManagerLoader instance;

    void Awake()
    {
        if (Loaded) return;
        instance = this;





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