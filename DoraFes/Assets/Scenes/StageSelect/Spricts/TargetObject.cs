using System.Collections;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    [SerializeField] private Transform[] targets; // �ǐՂ���I�u�W�F�N�g��Transform��z��ɂ���
    [SerializeField] private float distance = 5f; // �J�����ƒǐՃI�u�W�F�N�g�̋���
    private Transform target;  // �I�𒆂̃}�b�v
    private Quaternion initialRotation; // �J�����̏����p�x

    private MapFade fadeController; // �t�F�[�h�R���g���[���[

    private StageSelect.STAGENAME currentStage; // ���݂̃X�e�[�W

    void Start()
    {
        initialRotation = transform.rotation; // �J�����̏����p�x��ۑ�����
        target = targets[0]; // �ŏ��̃^�[�Q�b�g��ݒ肷��
        fadeController = FindObjectOfType<MapFade>(); // FadeController���擾����

        currentStage = StageSelect.StageName; // ���݂̃X�e�[�W������������
    }

    void Update()
    {


        // ���݂̃X�e�[�W���Ď����A�O��̃X�e�[�W�ƈقȂ�ꍇ�ɃJ�������ړ�����
        if (StageSelect.StageName != currentStage)
        {
            currentStage = StageSelect.StageName;
            MoveCamera(currentStage);
        }
    }
    private void MoveCamera(StageSelect.STAGENAME stage)
    {
        switch (stage)
        {
            // �}�b�v�P�Ɉړ�
            case StageSelect.STAGENAME.STAGE1_1:

                if (target != targets[1])
                {
                    StartCoroutine(FadeAndMove(targets[1]));

                    target = targets[1];
                }

                break;

            // �}�b�v�Q�Ɉړ�
            case StageSelect.STAGENAME.STAGE2_1:

                if (target != targets[2])
                {
                    StartCoroutine(FadeAndMove(targets[2]));

                    target = targets[2];
                }
                break;

            // �}�b�v�R�Ɉړ�
            case StageSelect.STAGENAME.STAGE3_1:
                if (target != targets[3])
                {
                    StartCoroutine(FadeAndMove(targets[3]));

                    target = targets[3];
                }
                break;

            // �}�b�v�S�Ɉړ�
            case StageSelect.STAGENAME.STAGE4_1:
                if (target != targets[4])
                {
                    StartCoroutine(FadeAndMove(targets[4]));

                    target = targets[4];
                }
                break;

            // �}�b�v�T�Ɉړ�
            //case StageSelect.STAGENAME.BACKTOMAP4:
            case StageSelect.STAGENAME.STAGE5_1:
                if (target != targets[5])
                {
                    StartCoroutine(FadeAndMove(targets[5]));

                    target = targets[5];
                }
                break;
        }
    }

    private IEnumerator FadeAndMove(Transform target)
    {
        fadeController.gameObject.SetActive(true); // �t�F�[�h�p��Image��L���ɂ���

        yield return StartCoroutine(fadeController.FadeOut()); // �t�F�[�h�A�E�g����

        // �J�����̈ʒu�Ɗp�x������������
        transform.position = target.position - transform.forward * distance;
        transform.rotation = initialRotation;

        yield return StartCoroutine(fadeController.FadeIn()); // �t�F�[�h�C������

        fadeController.gameObject.SetActive(false); // �t�F�[�h�p��Image�𖳌��ɂ���

        // �J�������A�N�e�B�u�ɂ���
        gameObject.SetActive(true);
    }

}
