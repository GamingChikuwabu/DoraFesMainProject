using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //ロード画面を表示する時間
    [SerializeField] private float LoadingTime = 5.0f;

    //ロードシーンのシーン名
    private string LoadName = "LoadScene";

    //次に遷移するシーンのシーン名
    private string NextLoadName;

    //Invokeを複数回呼び出さないための変数
    private bool isSceneChanging = false;

    // Start is called before the first frame update
    void Start()
    {
        NextLoadName = "";
    }

    // Update is called once per frame
    void Update()
    {
        //NextLoadNameが空欄のとき
        if(NextLoadName != "")
        {
            //現在のシーン名がLoadSceneじゃないとき
            if (SceneManager.GetActiveScene().name != "LoadScene")
            {
                //ロード画面を表示する
                SceneManager.LoadScene(LoadName);

                isSceneChanging = true;
            }
        }

        //現在のシーン名がLoadSceneのとき
        if(isSceneChanging && SceneManager.GetActiveScene().name == "LoadScene")
        {
            isSceneChanging = false;

            //指定時間後にChangeScene関数を呼び出す
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
