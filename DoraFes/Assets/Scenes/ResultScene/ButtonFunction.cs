using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunction : MonoBehaviour
{
    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    void Start()
    {
        //LoadScene�X�N���v�g�̕ϐ�������Ă���
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

    }

    public void StringArgFunction(string s)
    {
        //SceneManager.LoadScene(s);
        //���[�h��ʌ�ɑJ�ڂ�����V�[�������Z�b�g
        LS.SetLoadName(s);
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
