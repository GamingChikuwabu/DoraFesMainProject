using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunction : MonoBehaviour
{
    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    //���g���C����V�[����������Ă���
    private GameObject RetrySceneObject;
    private SetSceneName SNS;

    void Start()
    {
        //LoadScene�X�N���v�g�̕ϐ�������Ă���
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

        //���g���C����V�[����������Ă���
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
