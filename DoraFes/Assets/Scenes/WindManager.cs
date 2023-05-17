using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip seClip;

    [Header("���̐����Ԋu")]
    [SerializeField] float interval = 5f;
    [Header("���������I���܂ł̎���")]
    [SerializeField] float interval02 = 1f;
    float intervalCount = 0f;   // ���������Ԋu���J�E���g

    // *=*=*=*=*=*=*=*=*=*=*=*=*=*
    // �p�[�e�B�N���֘A�̕ϐ��錾
    public ParticleSystem particleSystem;
    private ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule;
    [Header("�΂��h�炮����")]
    [SerializeField] private float moveParticle = 18;

    // *=*=*=*=*=*=*=*=*=*=*=*=*=*
    // ���C�g�֘A�̕ϐ��錾
    [Header("�Ώۂ�Light")]
    public Light light = null;
    private float higtIntensity = 0f;   // �ω��O�̌��̖��邳�̒l
    [Header("Light�̕ω���̖��邳")]
    [SerializeField] private float lowIntensity = 200;
    [Header("�J�ڂɂ����鎞�ԁi�i�j")]
    [SerializeField] private float duration = 6f;
    [Header("�J�ڂɂ����鎞�ԁi�߁j")]
    [SerializeField] private float duration2 = 3f;
    float changStartTime = 0f;   // ���邳�̕ω��J�n�������i�[
    bool isChange = false;        // ���C�g�̖��邳���ω����Ă���̂�
    bool isHight = true;         // �ω��O�̃��C�g�̖��邳�����邢���ǂ���

    [SerializeField] GameObject[] grass;

    void Start()
    {
        // ���C�g�֘A
        higtIntensity = light.intensity;    // ���C�g�̕ω��O�̒l
        intervalCount = Time.time;          // ���݂̎������擾

        // �p�[�e�B�N���֘A
        forceOverLifetimeModule = particleSystem.forceOverLifetime;

        audioSource.clip = seClip;
    }

    void Update()
    {
        // ���邳���ω������ǂ���
        if (isChange)
        {
            // ���邳�������鏈��
            if (isHight)
            {
                float startIntensity = higtIntensity;
                float endIntensity = lowIntensity;
                bool act = false;
                act = ChangeLight(changStartTime, duration, startIntensity, endIntensity);

                // �������ׂėh�炷
                for (int i = 0; i < grass.Length; i++)
                {
                    GrassMoveWithWind grassMove = grass[i].GetComponent<GrassMoveWithWind>();
                    grassMove.GrassMove(changStartTime, duration, grassMove.startAngel.x, grassMove.endAngle.x);
                }

                // ���邳�̑J�ڂ���������
                if (act)
                {
                    isChange = false;
                    isHight = false;
                    intervalCount = Time.time;
                }
            }
            // ���邳���グ�鏈��
            else
            {
                float startIntensity = lowIntensity;
                float endIntensity = higtIntensity;
                bool act = false;
                act = ChangeLight(changStartTime, duration2, startIntensity, endIntensity);

                // �������ׂėh�炷
                for (int i = 0; i < grass.Length; i++)
                {
                    GrassMoveWithWind grassMove = grass[i].GetComponent<GrassMoveWithWind>();
                    grassMove.GrassMove(changStartTime, duration2, grassMove.endAngle.x, grassMove.startAngel.x);
                }

                // ���邳�̑J�ڂ���������
                if (act)
                {
                    isChange = false;
                    isHight = true;
                    intervalCount = Time.time;
                    forceOverLifetimeModule.x = 1;
                }
            }
        }
        else
        {
            if (isHight)
            {
                if (Time.time - intervalCount >= interval)
                {
                    changStartTime = Time.time;
                    isChange = true;
                    forceOverLifetimeModule.x = moveParticle;

                    audioSource.PlayOneShot(seClip);
                }
            }
            else
            {
                if (Time.time - intervalCount >= interval02)
                {
                    changStartTime = Time.time;
                    isChange = true;
                    forceOverLifetimeModule.x = 1f;
                }
            }
        }
    }





    // ���C�g�̃p���[��������֐�
    private bool ChangeLight(float startTime, float duration, float startPow, float endPow)
    {
        // ���݂̌o�ߎ���
        float elapsedTime = Time.time - startTime;

        // �o�ߎ��Ԃ�J�ڎ��ԂŊ���A0����1�܂ł̊����ɕϊ�
        float t = Mathf.Clamp01(elapsedTime / duration);

        // �ω��O�̒l�ƕω���̒l��t�̊����Ő��`��Ԃ����C�g�̋����ɑ��
        light.intensity = Mathf.Lerp(startPow, endPow, t);

        // �K�莞�Ԃ��o�߂����H
        if (t == 1) return true;
        return false;
    }
}
