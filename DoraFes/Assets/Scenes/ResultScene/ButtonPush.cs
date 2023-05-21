using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPush : MonoBehaviour
{
    [SerializeField] private string targetSceneName; // 遷移先のシーン名

    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    private void Start()
    {
        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();
    }

    public void OnClick()
    {
        //ロード画面後に遷移させるシーン名をセット
        LS.SetLoadName("1-1");
    }
}

