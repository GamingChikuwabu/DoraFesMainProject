using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryFadeOut : MonoBehaviour
{
    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    //���g���C����V�[����������Ă���
    private GameObject RetrySceneObject;
    private SetSceneName SNS;

    public Image fadeImage; // �t�F�[�h�p�̃C���[�W
    public float fadeSpeed = 1f; // �t�F�[�h�̑��x

    private float targetAlpha; // �t�F�[�h�̖ڕW�̃A���t�@�l

    void Start()
    {
        //LoadScene�X�N���v�g�̕ϐ�������Ă���
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();

        //���g���C����V�[����������Ă���
        RetrySceneObject = GameObject.Find("RetryScene");
        SNS = RetrySceneObject.GetComponent<SetSceneName>();

        // �t�F�[�h�p�̃C���[�W�̃A���t�@�l��������
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }

    void Update()
    {
        if (targetAlpha == 1.0f)
        {
            // �t�F�[�h�C���[�W�̃A���t�@�l��ڕW�l�Ɍ������ď��X�ɕω�������
            Color color = fadeImage.color;
            float newAlpha = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            color.a = newAlpha;
            fadeImage.color = color;

            if (color.a == 1.0f)
            {
                LS.SetLoadName(SNS.GetRetrySceneName());
            }
            
        }
        
    }

    public void StringFadeOut()
    {

        targetAlpha = 1f;
    }
}
