using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //ロード画面を表示する時間
    [SerializeField] private float LoadingTime = 3.0f;

    //ロードシーンのシーン名
    private string LoadName = "LoadScene";

    //次に遷移するシーンのシーン名

    public string NextLoadName ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NextLoadName != "")
        {
            if(SceneManager.GetActiveScene().name != "LoadScene")
            {
                SceneManager.LoadScene(LoadName);
            }
           
        }
        else if(SceneManager.GetActiveScene().name == "LoadScene")
        {
            Invoke("ChangeScene", LoadingTime);
        }

    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(NextLoadName);
        NextLoadName = "";
    }
    
}
