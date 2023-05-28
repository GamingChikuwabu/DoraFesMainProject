using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicNextScene : MonoBehaviour
{
    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    [Header("次に遷移するシーン")]
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Comic"))
        {
            //ロード画面後に遷移させるシーン名をセット
            //LS.SetLoadName(nextScene);
        }
    }
}
