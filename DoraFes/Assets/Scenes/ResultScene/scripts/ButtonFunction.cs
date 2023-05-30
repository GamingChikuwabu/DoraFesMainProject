using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    // ロードシーン用のオブジェクトを取ってくる変数
    private GameObject LoadSceneObject;
    private LoadScene LS;

    //リトライするシーン名を取ってくる変数
    private GameObject RetrySceneObject;
    private SetNowScene SNS;

    void Start()
    {
        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

        //リトライするシーン名を取ってくる
        RetrySceneObject = GameObject.Find("RetryScene");
        SNS = RetrySceneObject.GetComponent<SetNowScene>();
    }

    public void StringArgFunction(string s)
    {
        //SceneManager.LoadScene(s);
        //ロード画面後に遷移させるシーン名をセット
        LS.SetLoadName(s);
    }

    public void StringRetryScene()
    {
        string s = SNS.nowSceneName;
        LS.SetLoadName(s);
    }
   
}
