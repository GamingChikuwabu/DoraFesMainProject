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
        // �G�X�P�C�v�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �A�v���P�[�V�������I������
            Application.Quit();
        }
    }


}