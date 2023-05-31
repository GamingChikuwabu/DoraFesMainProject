using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_MoveMand : MonoBehaviour
{
    [Header("�A�j���[�V�����̊Ԋu")]
    public float intervalAnimation = 7f;
    // �ҋ@���Ԓ����ǂ����̃t���O
    bool isAnimation = false;


    [Header("�A�j���[�V�����ɂ����鎞��")]
    public float duration = 2f;
    [Header("�n��ɑҋ@���鎞��")]
    public float duration02 = 2f;
    // �n��ɑҋ@���邩�ǂ����̃t���O
    bool isInterval = true;



    float startPosY;    // �J�n�ʒu���i�[
    public float addNum = 20;
    float count;        // �������i�[
    bool isAnimPosi = true;


    


    void Start()
    {
        // �������W���i�[
        startPosY = transform.position.y;
        count = Time.time;
    }

    void Update()
    {
        if (isAnimation)
        {
            bool act = false;

            // �A�j���[�V�����̕��������������ǂ���
            if (isAnimPosi)
            {
                act = ChangePos(count, duration, startPosY, startPosY + addNum);
                if (act)
                {
                    isAnimPosi = false;
                    count = Time.time;
                    isInterval = true;
                }
            }
            else
            {
                if (isInterval)
                {
                    // �ҋ@������A�j���[�V������
                    if (Time.time - count >= duration02)
                    {
                        isInterval = false;
                        count = Time.time;
                    }
                }
                else
                {
                    act = ChangePos(count, duration, startPosY + addNum, startPosY);
                    if (act)
                    {
                        isAnimPosi = true;
                        count = Time.time;

                        isAnimation = false;
                    }
                }
            }
        }
        else
        {
            // �ҋ@������A�j���[�V������
            if (Time.time - count > intervalAnimation) 
            {
                isAnimation = true;
                count = Time.time;
            }
        }
    }





    private bool ChangePos(float startTime, float duration, float startPow, float endPow)
    {
        // ���݂̌o�ߎ���
        float elapsedTime = Time.time - startTime;

        // �o�ߎ��Ԃ�J�ڎ��ԂŊ���A0����1�܂ł̊����ɕϊ�
        float t = Mathf.Clamp01(elapsedTime / duration);

        // �ω��O�̒l�ƕω���̒l��t�̊����Ő��`��Ԃ����W����
        transform.position = new(
            transform.position.x,
            Mathf.Lerp(startPow, endPow, t),
            transform.position.z);

        // �K�莞�Ԃ��o�߂����H
        if (t == 1) return true;
        return false;
    }
}
