using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //���[�h��ʂ�\�����鎞��
    [SerializeField] private float LoadingTime = 3.0f;

    //���[�h�V�[���̃V�[����
    private string LoadName = "LoadScene";

    //���ɑJ�ڂ���V�[���̃V�[����

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
