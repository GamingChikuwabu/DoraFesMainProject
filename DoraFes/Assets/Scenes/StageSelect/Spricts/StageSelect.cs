using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public enum STAGENAME
    {
        // �}�b�v�I��
        MAPMIN,
        MAP1,
        MAP2,
        MAP3,
        MAP4,
        MAP5,
        MAPMAX,
        // �X�e�[�W�P
        STAGE1MIN,
        STAGE1_1,
        STAGE1_2,
        STAGE1_3,
        STAGE1_4,
        STAGE1_5,
        TOMAP2,
        STAGE1MAX,
        //�X�e�[�W�Q
        STAGE2MIN,
        BACKTOMAP1,
        STAGE2_1,
        STAGE2_2,
        STAGE2_3,
        STAGE2_4,
        STAGE2_5,
        TOMAP3,
        STAGE2MAX,
        //�X�e�[�W�R
        STAGE3MIN,
        BACKTOMAP2,
        STAGE3_1,
        STAGE3_2,
        STAGE3_3,
        STAGE3_4,
        STAGE3_5,
        TOMAP4,
        STAGE3MAX,
        //�X�e�[�W�S
        STAGE4MIN,
        BACKTOMAP3,
        STAGE4_1,
        STAGE4_2,
        STAGE4_3,
        STAGE4_4,
        STAGE4_5,
        TOMAP5,
        STAGE4MAX,
        //�X�e�[�W�T
        STAGE5MIN,
        BACKTOMAP4,
        STAGE5_1,
        STAGE5_2,
        STAGE5_3,
        STAGE5_4,
        STAGE5_5,
        STAGE5MAX,
    }

    // �I�𒆂̃X�e�[�W
    private static STAGENAME stageName;

    public static STAGENAME StageName
    {
        get { return stageName; }
        set { stageName = value; }
    }

    // �}�b�v�̏��
    private static STAGENAME mapState = STAGENAME.MAP1;

    public static STAGENAME MapState
    {
        get { return mapState; }
        set { mapState = value; }
    }

    //  �I���ł���X�e�[�W
    private static STAGENAME clearStage = STAGENAME.STAGE5_1;

    public static STAGENAME ClearStage
    {
        get { return clearStage; }
        set { clearStage = value; }
    }

    // �X���Ă��邩�ǂ���
    private bool stickInputTriggered;

    // SE
    [SerializeField] private AudioSource audioSourceSE1;
    [SerializeField] private AudioSource audioSourceSE2;

    StageNum stagenumUI;
    StageNum worldnumUI;
    //WorldActive worldnameUI;

    private int stageNumber =1;
    
    private int WorldNumber =1;
    

    void Start()
    {
        // ���߂ɑI�΂�Ă���X�e�[�W
        stageName = STAGENAME.MAP1;

        stickInputTriggered = false;

        stagenumUI = GameObject.Find("StageNum").GetComponent<StageNum>();
        worldnumUI = GameObject.Find("WorldNum").GetComponent<StageNum>();
        
        
    }

    void Update()
    {
        


        // FadeController �N���X�̃C���X�^���X���擾����
        MapFade fadeController = GameObject.FindObjectOfType<MapFade>();
        // �t�F�[�h���͏����ł��Ȃ�
        if (fadeController.IsFading)
        {
            return;
        }

        


        // �}�b�v�̏�Ԃ�ω�
        if (clearStage == STAGENAME.STAGE2_1)
        {
            mapState = STAGENAME.MAP2;
        }
        if (clearStage == STAGENAME.STAGE3_1)
        {
            mapState = STAGENAME.MAP3;
        }
        if (clearStage == STAGENAME.STAGE4_1)
        {
            mapState = STAGENAME.MAP4;
        }
        if (clearStage == STAGENAME.STAGE5_1)
        {
            mapState = STAGENAME.MAP5;
        }


        // ���X�e�B�b�N�̐��������̓��͂��擾
        float leftStickInput = Input.GetAxisRaw("L_Stick_Horizontal");

        // ���łɌX���Ă��邩
        if ((leftStickInput > 0.1f) && (!stickInputTriggered)  || (Input.GetKeyDown(KeyCode.D))) // �E�ɓ|�����ꍇ
        {
            stickInputTriggered = true;

            stageName += 1;

            stageNumber++;
            if (stageNumber == 6)
            {
                stageNumber = 5;
            }
            stagenumUI.ChangeNumber(stageNumber);

            switch (stageName)
            {
                case STAGENAME.MAP1:
                case STAGENAME.MAP2:
                case STAGENAME.MAP3:
                case STAGENAME.MAP4:
                case STAGENAME.MAP5:

                    // �}�b�v���I���ł��邩
                    if (stageName <= mapState)
                    {
                        // SE�̍Đ����s��
                        audioSourceSE1.Play();
                    }
                    else
                    {
                        stageName -= 1;
                        stageNumber--;
                        stagenumUI.ChangeNumber(stageNumber);
                    }
                    break;
            }
           
            // �X�e�[�W���I���ł��邩�ǂ���
            if (stageName <= clearStage)
            {
                // SE�̍Đ����s��
                audioSourceSE1.Play();
            }
            else
            {
                stageName -= 1;
                stageNumber--;
                stagenumUI.ChangeNumber(stageNumber);
            }

            
            // �X�e�[�W���I���ł��Ȃ��ꍇ
            if (stageName == STAGENAME.MAPMAX)
            {
                stageName = STAGENAME.MAP5;
            }
            if (stageName == STAGENAME.STAGE1MAX)
            {
                stageName = STAGENAME.TOMAP2;
            }
            if (stageName == STAGENAME.STAGE2MAX)
            {
                stageName = STAGENAME.TOMAP3;
            }
            if (stageName == STAGENAME.STAGE3MAX)
            {
                stageName = STAGENAME.TOMAP4;
            }
            if (stageName == STAGENAME.STAGE4MAX)
            {
                stageName = STAGENAME.TOMAP5;
            }
            if (stageName == STAGENAME.STAGE5MAX)
            {
                stageName = STAGENAME.STAGE5_5;
            }
            
        }


        else if (leftStickInput < -0.1f  && !stickInputTriggered || (Input.GetKeyDown(KeyCode.A))) // ���ɓ|�����ꍇ
        {
            // �X���Ă����Ԃ�
            stickInputTriggered = true;

            stageName -= 1;

            stageNumber--;
            if (stageNumber == 0)
            {
                stageNumber = 1;
            }
            stagenumUI.ChangeNumber(stageNumber);

            // SE�̍Đ����s��
            audioSourceSE1.Play();

           
            // �X�e�[�W���I���ł��Ȃ��ꍇ
            if (stageName == STAGENAME.MAPMIN)
                {
               
                stageName = STAGENAME.MAP1;
                }
                if (stageName == STAGENAME.STAGE1MIN)
                {
                
                stageName = STAGENAME.STAGE1_1;
                }
                if (stageName == STAGENAME.STAGE2MIN)
                {
                
                stageName = STAGENAME.BACKTOMAP1;
                }
                if (stageName == STAGENAME.STAGE3MIN)
                {
               
                stageName = STAGENAME.BACKTOMAP2;
                }
                if (stageName == STAGENAME.STAGE4MIN)
                {
               
                stageName = STAGENAME.BACKTOMAP3;
                }
                if (stageName == STAGENAME.STAGE5MIN)
                {
               
                stageName = STAGENAME.BACKTOMAP4;
                }
            
        }

        else if (leftStickInput <= 0.1f && leftStickInput >= -0.1f)
        {
            // �X�e�B�b�N���|����Ă��Ȃ��ꍇ�́A�g���K�[������
            stickInputTriggered = false;
        }

        // �I�𒆂̃X�e�[�W��
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
        {
            // SE�̍Đ����s��
            audioSourceSE2.Play();

            // �R���[�`�����J�n����
            StartCoroutine(WaitForSE(audioSourceSE2));

            stageNumber = 1;
            stagenumUI.ChangeNumber(stageNumber);
        }
    }

    // SE�̍Đ����I�������A�V�[���J�ڂ���
    IEnumerator WaitForSE(AudioSource audioSource)
    {
        // SE�̍Đ����I���܂őҋ@����
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        switch (stageName)
        {
            case STAGENAME.MAP1:

               
                WorldNumber = 1;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE1_1;

                break;

            case STAGENAME.MAP2:

                WorldNumber = 2;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE2_1;

                break;

            case STAGENAME.MAP3:

                WorldNumber = 3;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE3_1;

                break;

            case STAGENAME.MAP4:

                WorldNumber = 4;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE4_1;

                break;

            case STAGENAME.MAP5:

                WorldNumber = 5;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE5_1;

                break;

            case STAGENAME.STAGE1_1:

                SceneManager.LoadScene("1-1");

                break;

            case STAGENAME.STAGE1_2:

                break;

            case STAGENAME.STAGE1_3:

                break;

            case STAGENAME.STAGE1_4:

                break;

            case STAGENAME.STAGE1_5:

                break;

            case STAGENAME.TOMAP2:

                // �X�e�[�W�Q��
                WorldNumber = 2;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE2_1;

                break;

            case STAGENAME.BACKTOMAP1:

                //  �X�e�[�W�P��
                WorldNumber = 1;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE1_1;

                break;

            case STAGENAME.STAGE2_1:

                break;
            case STAGENAME.STAGE2_2:



                break;

            case STAGENAME.STAGE2_3:

                break;

            case STAGENAME.STAGE2_4:

                break;

            case STAGENAME.STAGE2_5:

                break;

            case STAGENAME.TOMAP3:

                // �X�e�[�W�R��
                WorldNumber = 3;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE3_1;

                break;

            case STAGENAME.BACKTOMAP2:

                //  �X�e�[�W�Q��
                WorldNumber = 2;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE2_1;

                break;

            case STAGENAME.STAGE3_1:


                break;

            case STAGENAME.STAGE3_2:

                break;

            case STAGENAME.STAGE3_3:

                break;

            case STAGENAME.STAGE3_4:

                break;

            case STAGENAME.STAGE3_5:

                break;

            case STAGENAME.TOMAP4:

                // �X�e�[�W�S��
                WorldNumber = 4;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE4_1;

                break;

            case STAGENAME.BACKTOMAP3:

                //  �X�e�[�W�R��
                WorldNumber = 3;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE3_1;

                break;

            case STAGENAME.STAGE4_1:

                break;

            case STAGENAME.STAGE4_2:

                break;

            case STAGENAME.STAGE4_3:

                break;

            case STAGENAME.STAGE4_4:

                break;

            case STAGENAME.STAGE4_5:

                break;

            case STAGENAME.TOMAP5:

                // �X�e�[�W�T��
                WorldNumber = 5;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE5_1;

                break;

            case STAGENAME.BACKTOMAP4:

                //  �X�e�[�W�S��
                WorldNumber = 4;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE4_1;

                break;

            case STAGENAME.STAGE5_1:

                break;

            case STAGENAME.STAGE5_2:

                break;

            case STAGENAME.STAGE5_3:

                break;

            case STAGENAME.STAGE5_4:

                break;

            case STAGENAME.STAGE5_5:

                break;
        }
    }
}
