using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageSelectInput;
using UnityEngine.UI;


public class SelectWorld : MonoBehaviour
{
    [Header("�t�F�[�h�pUI��n��")]
    public Image fadeUI;
    [Header("���֘A")]
    public AudioSource audioSource;
    public AudioClip seClip;
    [Header("�J�[�\���̈ړ����W")]
    [SerializeField] Vector3[] ConstPos = new Vector3[5];
    [Header("���[���h�}�b�v��n��")]
    public GameObject objWorldMap;
    [Header("�J������n��")]
    public GameObject objCamera;
    [Header("UI��n��")]
    [SerializeField]�@GameObject[] objUI;
    [Header("�}�b�v�̃`�F�b�N��n��")]
    [SerializeField] GameObject[] objCheck;
    [Header("�}�b�v��n��")]
    [SerializeField] GameObject[] objMAP;
    [Header("�Z�[�u�f�[�^��n��")]
    public SaveData saveData;

    private StageSelectInput stInput;   // ���͏����擾����֐�
    private StickNaturalMove stickMove; // �X�e�B�b�N��h�炷�N���X
    
    // ���ݑI�����Ă��郏�[���h�̐������i�[
    [System.NonSerialized] public int nowSelectWorld = 5;
    // ���ݑI�����Ă���X�e�[�W�̐������i�[
    [System.NonSerialized] public int nowSelectStage = 0;

    int nClearDataW;    // �Ō�ɃN���A�������[���h���i�[�i�X�e�[�W��5�̏ꍇ�{�P�j
    int nClearDataS;    // �Ō�ɃN���A�����X�e�[�W���i�[


    [Header("�J�����̈ړ��Ŏg���ϐ�")]
    public float duration = 1f;     // �ړ����ԁi�b�j
    float count;                    // �o�ߎ��Ԃ��i�[
    Vector3 startPos;               // �J�����̏������W���i�[
    public Vector3 endPos;          // �ړ���̍��W
    Vector3 startAngle;             // �J�����̏����p�x���i�[
    public Vector3 endAngle;        // �ړ���̊p�x

    enum ST_MODE
    {
        WORLDSELECT,    // ���[���h�Z���N�g��
        CAMRAMOVE,      // �J�����ړ���
        STAGESELECT,    // �X�e�[�W�Z���N�g��
    }
    // ���݂̏����󋵂��i�[
    ST_MODE stMode = ST_MODE.WORLDSELECT;
    [Header("�t�F�[�h�X�s�[�h")]
    public float fadeSpeed = 1;

    enum FADE
    {
        IN,
        OUT,
    }

    FADE fade = FADE.IN;

    void Start()
    {
        // �������W����
        transform.position = ConstPos[nowSelectWorld];
        // �R���|�[�l���g�擾
        stInput = gameObject.GetComponent<StageSelectInput>();
        stickMove = gameObject.GetComponent<StickNaturalMove>();

        //string�f�[�^���󂯎��
        string�@sClearData = saveData.GetString();

        // NULL�̏ꍇ
        if (sClearData == null) nClearDataW = 1;
        else
        {
            // ���[���h�����擾
            nClearDataW = int.Parse(sClearData.Substring(0, 1));
            // �X�e�[�W�����擾
            int nClearDataS = int.Parse(sClearData.Substring(2, 1));
            // 2-5�̏ꍇ
            if (nClearDataS == 5) nClearDataW++;
        }

        nClearDataW--;
        nClearDataS--;
    }

    private void Awake()
    {
        nowSelectWorld = 0;
        startPos = objCamera.transform.position;
        startAngle = objCamera.transform.eulerAngles;
    }

    void Update()
    {
        // ���͏����X�V
        stInput.CheakInput();

        if (stMode == ST_MODE.WORLDSELECT) UpdateWSM();
        else if (stMode == ST_MODE.CAMRAMOVE)
        {
            // ���݂̌o�ߎ���
            float elapsedTime = Time.time - count;

            // �o�ߎ��Ԃ�J�ڎ��ԂŊ���A0����1�܂ł̊����ɕϊ�
            float t = Mathf.Clamp01(elapsedTime / duration);

            // �J�������ړ�
            objCamera.transform.position = new(objCamera.transform.position.x,
                Mathf.Lerp(startPos.y, endPos.y, t),
                Mathf.Lerp(startPos.z, endPos.z, t));
            // �J�����̉�]
            objCamera.transform.eulerAngles = new(Mathf.Lerp(startAngle.x, endAngle.x, t),
                Mathf.Lerp(startAngle.y, endAngle.y, t),
                Mathf.Lerp(startAngle.z, endAngle.z, t));

            if (fade == FADE.IN)
            {
                Color color = fadeUI.color;
                color.a += Time.deltaTime * fadeSpeed;
                fadeUI.color = color;

                if (color.a > 1)
                {
                    color.a = 1;
                    fade = FADE.OUT;
                    // *=*=*=*=*=**=*=*=***=***=*=*==*=**=*=*===*=**=*==*==*=*
                    // �摜��؂�ւ�
                    // �`�F�b�N�}�[�N�����ׂď���
                    for (int i = 0; i < objCheck.Length; i++) objCheck[i].SetActive(false);
                    objWorldMap.SetActive(false);   // ���[���h�}�b�v������
                    // �I�����[���h���A�N�e�B�u��
                    objMAP[nowSelectWorld].SetActive(true);
                }
            }
            else if (fade == FADE.OUT)
            {
                Color color = fadeUI.color;
                color.a -= Time.deltaTime * fadeSpeed;
                fadeUI.color = color;

                if (color.a < 0) color.a = 0;
            }

            // �J�����̑J�ڏI��
            if (t == 1) stMode = ST_MODE.STAGESELECT;
        }
        else if (stMode == ST_MODE.STAGESELECT)
        {

        }

        




        UpdateUI(); // ���[���hUI�X�V�֐�
    }

    // UI���X�V����֐�
    void UpdateUI()
    {
        // ���ׂĂ�UI���A�N�e�B�u��
        for (int i = 0;i < objUI.Length; i++) objUI[i].SetActive(false);
        // �I�𒆂̃��[���hUI 
        objUI[nowSelectWorld].SetActive(true);
    }

    void UpdateWSM()
    {
        // �v���X�����ɓ��͂��ꂽ
        if (stInput.isBottom == IsInputBottom.STICK_H_P)
        {
            nowSelectWorld += 1;
            // ���[���h�I���Œ[�����ɍs�����ꍇ
            if (nowSelectWorld > 4) nowSelectWorld = 0;
            // �I���ł��Ȃ����[���h�Ɉړ����悤�Ƃ��Ă���Ȃ�
            if (nClearDataW < nowSelectWorld) nowSelectWorld -= 1;
            else audioSource.PlayOneShot(seClip);
        }
        // �}�C�i�X�����ɓ��͂��ꂽ
        else if (stInput.isBottom == IsInputBottom.STICK_H_N)
        {
            nowSelectWorld -= 1;
            // ���[���h�I���Œ[�����ɍs�����ꍇ
            if (nowSelectWorld < 0) nowSelectWorld = 4;
            // �I���ł��Ȃ����[���h�Ɉړ����悤�Ƃ��Ă���Ȃ�
            if (nClearDataW < nowSelectWorld) nowSelectWorld = 0;
            else audioSource.PlayOneShot(seClip);
        }
        else if (stInput.isBottom == IsInputBottom.A)
        {
            stMode = ST_MODE.CAMRAMOVE;
            count = Time.time;
            // *=*=*=*=*=*=*=*=*=***=*=**=*=*=*=*=*=*=*=**=*
            // �R�R�ɑI��SE��炷�֐���ǉ�����
            // *=*=*=*=**=*=**=*=**==****=****=**=*****=***=
        }

        // �}�̈ʒu��I���ʒu�ֈړ�
        transform.position = ConstPos[nowSelectWorld];
        // �X�e�B�b�N���㉺�ɗh�炷�֐�
        stickMove.MoveStick();
    }
}