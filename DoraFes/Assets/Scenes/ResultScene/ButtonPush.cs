using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPush : MonoBehaviour
{
    [SerializeField] private string targetSceneName; // �J�ڐ�̃V�[����

    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    private void Start()
    {
        //LoadScene�X�N���v�g�̕ϐ�������Ă���
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();
    }

    public void OnClick()
    {
        //���[�h��ʌ�ɑJ�ڂ�����V�[�������Z�b�g
        LS.SetLoadName("1-1");
    }
}

