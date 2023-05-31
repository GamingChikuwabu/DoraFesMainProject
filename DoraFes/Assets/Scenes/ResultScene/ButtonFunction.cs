using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunction : MonoBehaviour
{
    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    //リトライするシーン名を取ってくる
    private GameObject RetrySceneObject;
    private SetSceneName SNS;

    void Start()
    {
        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

        //リトライするシーン名を取ってくる
        RetrySceneObject = GameObject.Find("RetryScene");
        SNS = RetrySceneObject.GetComponent<SetSceneName>();

    }

    public void StringArgFunction(string s)
    {
        LS.SetLoadName(s);
    }


    // Start is called before the first frame update

    public void RetryFunction()
    {
        LS.SetLoadName(SNS.GetRetrySceneName());
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
