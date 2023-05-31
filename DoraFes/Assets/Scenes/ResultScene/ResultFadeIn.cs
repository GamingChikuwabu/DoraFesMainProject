using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultFadeIn : MonoBehaviour
{
    public Image fadeImage; // �t�F�[�h�p�̃C���[�W

    [Header("�X�s�[�h")]
    [SerializeField]private float fadeSpeed = 1f; // �t�F�[�h�̑��x

    private float targetAlpha = 0f; // �t�F�[�h�̖ڕW�̃A���t�@�l

    void Start()
    {
        // �t�F�[�h�p�̃C���[�W�̃A���t�@�l��������
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        // �t�F�[�h�C�����J�n
        StartFadeIn();
    }

    void Update()
    {
        // �t�F�[�h�C���[�W�̃A���t�@�l��ڕW�l�Ɍ������ď��X�ɕω�������
        Color color = fadeImage.color;
        float newAlpha = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
        color.a = newAlpha;
        fadeImage.color = color;
    }

    void StartFadeIn()
    {
        targetAlpha = 0f; // �t�F�[�h�C���̖ڕW�̃A���t�@�l��0�ɐݒ�
    }
}
