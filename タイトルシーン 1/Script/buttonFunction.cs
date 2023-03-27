using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
   
    public void OnClick(string sceneName)
    {
        //シーンの読み込み
        //引数にシーン名を指定する
        SceneManager.LoadScene(sceneName);
    }

    public void OnClick2()
    {
        //アプリケーションの終了
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
