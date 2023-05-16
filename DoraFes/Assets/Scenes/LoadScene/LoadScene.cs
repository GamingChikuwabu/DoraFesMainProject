using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //ロード画面を表示する時間
    [SerializeField] private float LoadingTime;

    //ロードシーンのシーン名
    private string LoadName = "LoadScene";

    //次に遷移するシーンのシーン名
    private string NextLoadName;

    // Start is called before the first frame update
    void Start()
    {
        NextLoadName = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(NextLoadName != "")
        {
            if (SceneManager.GetActiveScene().name != "LoadScene")
            {
                SceneManager.LoadScene(LoadName);
            }
        }

        if(SceneManager.GetActiveScene().name == "LoadScene")
        {
            Invoke("ChangeScene", LoadingTime);
        }
    }

    //シーンをロードする関数
    private void ChangeScene()
    {
        SceneManager.LoadScene(NextLoadName);
        NextLoadName = "";
    }

    //次に遷移するシーン名をセットする関数
    public void SetLoadName(string a)
    {
        NextLoadName = a;
    }
    
}
