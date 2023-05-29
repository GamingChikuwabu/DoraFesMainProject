using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectCameraMove : MonoBehaviour
{
    // �J�n�A�j���[�V�����Ŏg�p����ϐ�
    public float animTime01 = 4;    // ��P�A�j���[�V�����ɂ����鎞��
    public float animTime02 = 1;    // ��Q�A�j���[�V�����ɂ����鎞��
    public float animTime03 = 1;    // ��Q�A�j���[�V�����ɂ����鎞��

    bool isAnim01 = true;       // ��P�A�j���[�V���������ǂ���
    bool isAnim02 = true;       // ��Q�A�j���[�V���������ǂ���
    bool isAnim03 = true;       // ��Q�A�j���[�V���������ǂ���

    float HankeiZ;              // ��P�A�j���[�V�����Ŏg�p�����]���a
    


    float count;    // �^�C��

    float startPosYAnim02;      // ��Q�A�j���[�V�����Ŏg�p�����]���a
    float endPosYAnim02 = 67;   // ��Q�A�j���[�V�����ł̏I���ʒuY


    public GameObject cursol;
    public GameObject[] deleteObj;

    public Image fadeUI;
    public float fadeSpeed;

    void Start()
    {
        startPosYAnim02 = transform.position.y;

        HankeiZ = transform.position.z;
        count = Time.time;
    }

    void Update()
    {
        if (fadeUI.color.a > 0)
        {
            Color color = fadeUI.color;
            color.a -= Time.deltaTime * fadeSpeed;
            fadeUI.color = color;
        }
        else
        {
            Color color = fadeUI.color;
            color.a = 0;
            fadeUI.color = color;
        }



        // ���A�j���[�V����
        if (isAnim01)
        {
            // �J�������W�ړ�
            transform.position = new((HankeiZ + 10) * -Mathf.Sin((Time.time - count) / animTime01 * 180 * Mathf.Deg2Rad),
                transform.position.y,
                HankeiZ * Mathf.Cos((Time.time - count) / animTime01 * 180 * Mathf.Deg2Rad));
            // �J������]
            transform.eulerAngles = new(transform.eulerAngles.x,
                90 * Mathf.Cos((Time.time - count) / animTime01 * 180 * Mathf.Deg2Rad) + 90,
                transform.eulerAngles.z);

            if (Time.time - count > animTime01)
            {
                // �J�������W�ړ�
                transform.position = new((HankeiZ + 10) * -Mathf.Sin(180 * Mathf.Deg2Rad),
                    transform.position.y,
                    HankeiZ * Mathf.Cos(180 * Mathf.Deg2Rad));
                // �J������]
                transform.eulerAngles = new(transform.eulerAngles.x,
                    90 * Mathf.Cos(180 * Mathf.Deg2Rad) + 90,
                    transform.eulerAngles.z);

                count = Time.time;
                isAnim01 = false;
            }
        }
        else if (isAnim02)
        {
            // ���݂̌o�ߎ���
            float elapsedTime = Time.time - count;

            // �o�ߎ��Ԃ�J�ڎ��ԂŊ���A0����1�܂ł̊����ɕϊ�
            float t = Mathf.Clamp01(elapsedTime / animTime02);

            // �ω��O�̒l�ƕω���̒l��t�̊����Ő��`��Ԃ����C�g�̋����ɑ��
            transform.position = new(transform.position.x,
                Mathf.Lerp(startPosYAnim02, endPosYAnim02, t),
                transform.position.z);

            // �K�莞�Ԃ��o�߂����H
            if (t == 1)
            {
                transform.position = new(0,
                transform.position.y,
                transform.position.z);

                count = Time.time;
                isAnim02 = false;
            }
        }
        else if (isAnim03)
        {
            if (Time.time - count > animTime03)
            {
                for (int i = 0; deleteObj.Length > i; i++)
                {
                    Destroy(deleteObj[i]);
                }
                // �J�[�\�����A�N�e�B�u��
                cursol.SetActive(true);
                // ���̃X�N���v�g����菜��
                Destroy(GetComponent<StageSelectCameraMove>());
            }
        }
    }
}
