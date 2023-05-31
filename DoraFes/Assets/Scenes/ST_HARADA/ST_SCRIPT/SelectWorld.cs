using UnityEngine;
using static StageSelectInput;
using UnityEngine.UI;


public class SelectWorld : MonoBehaviour
{
    // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=
    // �܂��悵
    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    // ���g���C����V�[����������Ă���
    private GameObject RetrySceneObject;
    //private SetSceneName SNS;
    // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=

    [Header("�t�F�[�h�pUI��n��")]
    public Image fadeUI;
    [Header("���֘A")]
    public AudioSource audioSource;
    public AudioClip seClip;    // �ړ���
    public AudioClip seClip02;  // ���ۉ�
    public AudioClip seClip03;  // ���艹
    public AudioClip seClip04;  // ���[���h�ړ���
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
    [Header("�X�e�[�W�A�C�R����n��")]
    [SerializeField] GameObject[] objStage;
    [Header("�Z�[�u�f�[�^��n��")]
    public SaveData saveData;

    private StageSelectInput stInput;   // ���͏����擾����֐�
    private StickNaturalMove stickMove; // �X�e�B�b�N��h�炷�N���X
    
    // ���ݑI�����Ă��郏�[���h�̐������i�[
    [System.NonSerialized] public int nowSelectWorld = 1;
    // ���ݑI�����Ă���X�e�[�W�̐������i�[
    [System.NonSerialized] public int nowSelectStage = 1;

    int nClearDataW = 0;    // �Ō�ɃN���A�������[���h���i�[�i�X�e�[�W��4�̏ꍇ�{�P�j
    int nClearDataS = 0;    // �Ō�ɃN���A�����X�e�[�W���i�[


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
        FADEOUT,        // �t�F�[�h�A�E�g��
    }
    // ���݂̏����󋵂��i�[
    ST_MODE stMode = ST_MODE.WORLDSELECT;
    [Header("�t�F�[�h�X�s�[�h")]
    public float fadeSpeed = 1;
    public float fadeSpeed02 = 1;

    enum FADE
    {
        IN,
        OUT,
    }

    FADE fade = FADE.IN;

    // Icon�̏������W���i�[
    Vector3[] iconPos = new Vector3[5 * 4]; // �R�R�����ύX�i�X�e�[�W���̕ύX�̏ꍇ�j
    [Header("�A�C�R���֘A")]
    public float moveSpeed = 0.5f;
    public float movePow = 2;
    int stageNum = 4;        // �X�e�[�W��;

    void Start()
    {
        // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=
        // �܂��悵
        // LoadScene�X�N���v�g�̕ϐ�������Ă���
        //LoadSceneObject = GameObject.Find("LoadScene");
        //LS = LoadSceneObject.GetComponent<LoadScene>();

        //// ���g���C����V�[����������Ă���
        //RetrySceneObject = GameObject.Find("RetryScene");
        //SNS = RetrySceneObject.GetComponent<SetSceneName>();
        // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=


        // �������W����
        transform.position = ConstPos[nowSelectWorld - 1];
        // �R���|�[�l���g�擾
        stInput = gameObject.GetComponent<StageSelectInput>();
        stickMove = gameObject.GetComponent<StickNaturalMove>();

        // string�f�[�^���󂯎��
        string�@sClearData = saveData.GetString();

        // NULL�̏ꍇ
        if (sClearData == "")
        {
            nClearDataW = 1;
            nClearDataS = 0;
        }
        else
        {
            // ���[���h�����擾
            nClearDataW = int.Parse(sClearData.Substring(0, 1));
            // �X�e�[�W�����擾
            nClearDataS = int.Parse(sClearData.Substring(2, 1));
            // ~-4�̏ꍇ
            if (nClearDataS == stageNum)
            {
                nClearDataW++;
                nClearDataS = 0;
            }
        }

        nClearDataS++;

        // ���[���h������
        for (int i = 0; i < 5; i++)
        {
            // �X�e�[�W������
            for (int j = 0; j < stageNum; j++)
            {
                if ((nClearDataW - 1) * stageNum + nClearDataS - 1 < i * stageNum + j)
                {
                    Material material = objStage[i * stageNum + j].GetComponent<Renderer>().material;
                    material.DisableKeyword("_EMISSION");// ���˂𖳌���
                }
            }
        }

        // icon�̏������W���i�[
        for (int i = 0; i < 5 * stageNum; i++)
        {
            iconPos[i] = objStage[i].transform.localPosition;
        }
            
    }

    private void Awake()
    {
        startPos = objCamera.transform.position;
        startAngle = objCamera.transform.eulerAngles;
    }

    void Update()
    {
        // ���͏����X�V
        stInput.CheakInput();

        if (stMode == ST_MODE.WORLDSELECT) UpdateWSM();
        else if (stMode == ST_MODE.CAMRAMOVE) UpdateCMM();
        else if (stMode == ST_MODE.STAGESELECT) UpdateSSM();
        else if (stMode == ST_MODE.FADEOUT)
        {
            Color color = fadeUI.color;
            color.a += Time.deltaTime * fadeSpeed02;
            fadeUI.color = color;

            if (color.a > 1)
            {
                // �R�R�ɓ����
                string stage = nowSelectWorld + "-" + nowSelectStage;

                // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=
                // �܂��悵
                //LS.SetLoadName(stage);
                //SNS.SetRetrySceneName(stage);
                // =*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=


            }
        }

        UpdateUI(); // ���[���hUI�X�V�֐�
    }



    // UI���X�V����֐�
    void UpdateUI()
    {
        // ���ׂĂ�UI���A�N�e�B�u��
        for (int i = 0;i < objUI.Length; i++) objUI[i].SetActive(false);
        // �I�𒆂̃��[���hUI 
        objUI[(nowSelectWorld - 1)].SetActive(true);
    }

    // ���[���h�Z���N�g���[�h�̍X�V�֐�
    void UpdateWSM()
    {
        for (int i = 0; i < 5; i++)
        {
            objCheck[i].SetActive(false);
        }
        

        // �v���X�����ɓ��͂��ꂽ
        if (stInput.isBottom == IsInputBottom.STICK_H_P)
        {
            nowSelectWorld += 1;
            // ���[���h�I���Œ[�����ɍs�����ꍇ
            if (nowSelectWorld > 5) nowSelectWorld = 1;
            // �I���ł��Ȃ����[���h�Ɉړ����悤�Ƃ��Ă���Ȃ�
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld -= 1;
                audioSource.PlayOneShot(seClip02);
            }
            else audioSource.PlayOneShot(seClip);
        }
        // �}�C�i�X�����ɓ��͂��ꂽ
        else if (stInput.isBottom == IsInputBottom.STICK_H_N)
        {
            nowSelectWorld -= 1;
            // ���[���h�I���Œ[�����ɍs�����ꍇ
            if (nowSelectWorld < 1) nowSelectWorld = 5;
            // �I���ł��Ȃ����[���h�Ɉړ����悤�Ƃ��Ă���Ȃ�
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld = 1;
                audioSource.PlayOneShot(seClip02);
            }
            else audioSource.PlayOneShot(seClip);
        }
        else if (stInput.isBottom == IsInputBottom.A)
        {
            stMode = ST_MODE.CAMRAMOVE;
            count = Time.time;
            // ���b�V�������_���[�𖳌�������
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            audioSource.PlayOneShot(seClip03);
        }

        objCheck[nowSelectWorld - 1].SetActive(true);

        // �}�̈ʒu��I���ʒu�ֈړ�
        transform.position = ConstPos[(nowSelectWorld - 1)];
        // �X�e�B�b�N���㉺�ɗh�炷�֐�
        stickMove.MoveStick();
    }

    // �J�������[�u���[�h�̍X�V�֐�
    void UpdateCMM()
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
                // �`�F�b�N�}�[�N�����ׂď���
                for (int i = 0; i < objCheck.Length; i++) objCheck[i].SetActive(false);
                objWorldMap.SetActive(false);// ���[���h�}�b�v������

                // �I�����[���h���A�N�e�B�u��
                objMAP[(nowSelectWorld - 1)].SetActive(true);
                // �X�e�[�W�A�C�R�����A�N�e�B�u��
                for (int i = 0; i < stageNum; i++) objStage[(nowSelectWorld - 1) * stageNum + i].SetActive(true);
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

    // �t�F�[�h�A�E�g���[�h�̍X�V�֐�
    void UpdateSSM()
    {
        // �I�����[���h���A�N�e�B�u��
        objMAP[(nowSelectWorld - 1)].SetActive(false);
        // �X�e�[�W�A�C�R�����A�N�e�B�u��
        for (int i = 0; i < stageNum; i++) objStage[(nowSelectWorld - 1) * stageNum + i].SetActive(false);

        // �v���X�����ɓ��͂��ꂽ
        if (stInput.isBottom == IsInputBottom.R)
        {
            nowSelectWorld += 1;
            // ���[���h�I���Œ[�����ɍs�����ꍇ
            if (nowSelectWorld > 5) nowSelectWorld = 1;
            // �I���ł��Ȃ����[���h�Ɉړ����悤�Ƃ��Ă���Ȃ�
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld -= 1;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                nowSelectStage = 1;
                audioSource.PlayOneShot(seClip04);
            }
        }
        // �}�C�i�X�����ɓ��͂��ꂽ
        else if (stInput.isBottom == IsInputBottom.L)
        {
            nowSelectWorld -= 1;
            // ���[���h�I���Œ[�����ɍs�����ꍇ
            if (nowSelectWorld < 1) nowSelectWorld = 5;
            // �I���ł��Ȃ����[���h�Ɉړ����悤�Ƃ��Ă���Ȃ�
            if (nClearDataW < nowSelectWorld)
            {
                nowSelectWorld = 1;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                nowSelectStage = 1;
                audioSource.PlayOneShot(seClip04);
            }
        }
        else if (stInput.isBottom == IsInputBottom.STICK_H_P)
        {
            nowSelectStage++;

            // �i�߂Ȃ��X�e�[�W�Ɉړ����悤�Ƃ���
            if ((nClearDataW - 1) * stageNum + nClearDataS - 1 < (nowSelectWorld - 1) * stageNum + nowSelectStage - 1)
            {
                nowSelectStage--;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                // �X�e�[�W���}�b�N�X�𒴂�����
                if (nowSelectStage > stageNum)
                {
                    nowSelectStage = 1;
                    nowSelectWorld++;
                    audioSource.PlayOneShot(seClip04);
                }
                else
                {
                    audioSource.PlayOneShot(seClip);
                }
            }
        }
        else if (stInput.isBottom == IsInputBottom.STICK_H_N)
        {
            nowSelectStage--;

            // �i�߂Ȃ��X�e�[�W�Ɉړ����悤�Ƃ���
            if (1 > (nowSelectWorld - 1) * stageNum + nowSelectStage)
            {
                nowSelectStage++;
                audioSource.PlayOneShot(seClip02);
            }
            else
            {
                // �X�e�[�W���}�b�N�X�𒴂�����
                if (nowSelectStage < 1)
                {
                    nowSelectStage = stageNum;
                    nowSelectWorld--;
                    audioSource.PlayOneShot(seClip04);
                }
                else
                {
                    audioSource.PlayOneShot(seClip);
                }
            }
        }
        else if (stInput.isBottom == IsInputBottom.A)
        {
            stMode = ST_MODE.FADEOUT;
        }

        // �I�����[���h���A�N�e�B�u��
        objMAP[(nowSelectWorld - 1)].SetActive(true);
        // �X�e�[�W�A�C�R�����A�N�e�B�u��
        for (int i = 0; i < stageNum; i++) objStage[(nowSelectWorld - 1) * stageNum + i].SetActive(true);

        // ���W�ʒu�����ɖ߂�
        for (int i = 0; i < stageNum; i++)
        {
            objStage[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].transform.localPosition = new(
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].x,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].y,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].z);
        }

        // �I�𒆂̃A�C�R����h�炷
        objStage[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].transform.localPosition = new(
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].x,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].y + Mathf.Sin(Time.time * moveSpeed) * movePow,
                iconPos[(nowSelectWorld - 1) * stageNum + nowSelectStage - 1].z);
    }
}