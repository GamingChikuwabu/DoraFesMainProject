using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicNextScene : MonoBehaviour
{
    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    [Header("���ɑJ�ڂ���V�[��")]
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        //LoadScene�X�N���v�g�̕ϐ�������Ă���
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Comic"))
        {
            //���[�h��ʌ�ɑJ�ڂ�����V�[�������Z�b�g
            //LS.SetLoadName(nextScene);
        }
    }
}
