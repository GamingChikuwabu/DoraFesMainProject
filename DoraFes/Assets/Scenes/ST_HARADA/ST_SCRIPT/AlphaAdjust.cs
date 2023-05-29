using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAdjust : MonoBehaviour
{
    public float startValue = 0; // �����l
    public float endtValue = 1.0f; // �ω���̒l

    [Header("�J�ڂɂ����鎞��")]
    [SerializeField] private float duration = 1f;
    float count = 0;
    int isPositive = 0;

    private Renderer renderer;

    [Header("���g�̃��[���h�i���o�[������")]
    public int myNumber;

    public GameObject stick;
    SelectWorld act;
    MeshRenderer meshRenderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        act = stick.GetComponent<SelectWorld>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    private void Update()
    {
        if (act.nowSelectWorld == myNumber)
        {
            meshRenderer.enabled = true;
            ChangeAlpha();
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    // ���l��ύX����֐�
    private void ChangeAlpha()
    {
        // �}�e���A���̃J���[�v���p�e�B���擾
        Color color = renderer.material.color;

        // ���݂̌o�ߎ���
        float elapsedTime = Time.time - count;

        // �o�ߎ��Ԃ�J�ڎ��ԂŊ���A0����1�܂ł̊����ɕϊ�
        float t = Mathf.Clamp01(elapsedTime / duration);
        if (isPositive % 2 == 0) color.a = Mathf.Lerp(startValue, endtValue, t);
        else color.a = Mathf.Lerp(endtValue, startValue, t);

        // �ύX�����J���[�v���p�e�B���}�e���A���ɐݒ�
        renderer.material.color = color;

        // �K�莞�Ԃ��o�߂����H
        if (t == 1)
        {
            isPositive++;
            count = Time.time;
        }
    }
}
