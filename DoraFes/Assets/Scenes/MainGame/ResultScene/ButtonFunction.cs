using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunction : MonoBehaviour
{
    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    void Start()
    {
        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

    }

    public void StringArgFunction(string s)
    {
        //SceneManager.LoadScene(s);
        //ロード画面後に遷移させるシーン名をセット
        LS.SetLoadName(s);
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
