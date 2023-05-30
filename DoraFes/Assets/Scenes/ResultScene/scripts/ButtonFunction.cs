using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���ϐ�
    private GameObject LoadSceneObject;
    private LoadScene LS;

    //���g���C����V�[����������Ă���ϐ�
    private GameObject RetrySceneObject;
    private SetNowScene SNS;

    void Start()
    {
        //LoadScene�X�N���v�g�̕ϐ�������Ă���
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

        //���g���C����V�[����������Ă���
        RetrySceneObject = GameObject.Find("RetryScene");
        SNS = RetrySceneObject.GetComponent<SetNowScene>();
    }

    public void StringArgFunction(string s)
    {
        //SceneManager.LoadScene(s);
        //���[�h��ʌ�ɑJ�ڂ�����V�[�������Z�b�g
        LS.SetLoadName(s);
    }

    public void StringRetryScene()
    {
        string s = SNS.nowSceneName;
        LS.SetLoadName(s);
    }
   
}
