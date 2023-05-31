using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour
{
    //���g���C����V�[����������Ă���
    private GameObject RetrySceneObject;
    private SetSceneName SNS;

    public  enum STAGENAME
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

    private bool isFade;

    // Start is called before the first frame update
    void Start()
    {
        // ���߂ɑI�΂�Ă���X�e�[�W
        stageName = STAGENAME.MAP1;

        //���g���C����V�[����������Ă���
        RetrySceneObject = GameObject.Find("RetryScene");
        SNS = RetrySceneObject.GetComponent<SetSceneName>();
    }

    // Update is called once per frame
    void Update()
    {
        MapFade fadeController = GameObject.FindObjectOfType<MapFade>(); // FadeController �N���X�̃C���X�^���X���擾����
        if (fadeController.IsFading)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            stageName += 1;

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            stageName -= 1;

            // �X�e�[�W���I���ł��Ȃ��ꍇ
            if (stageName == STAGENAME.MAPMIN)
            {
                stageName = STAGENAME.MAP1;
            }
            if (stageName==STAGENAME.STAGE1MIN)
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

        // �I�𒆂̃X�e�[�W��
        if(Input.GetKeyDown(KeyCode.Return))
        {
            switch(stageName)
            {
                case STAGENAME.MAP1:

                    stageName = STAGENAME.STAGE1_1;

                    break;

                case STAGENAME.MAP2:

                    stageName = STAGENAME.STAGE2_1;

                    break;

                case STAGENAME.MAP3:

                    stageName = STAGENAME.STAGE3_1;

                    break;

                case STAGENAME.MAP4:

                    stageName = STAGENAME.STAGE4_1;

                    break;

                case STAGENAME.MAP5:

                    stageName = STAGENAME.STAGE5_1;

                    break;

                case STAGENAME.STAGE1_1:

                    SceneManager.LoadScene("1-1");

                    SNS.SetRetrySceneName("1-1");

                    break;

                case STAGENAME.STAGE1_2:

                    SceneManager.LoadScene("1-2");

                    break;

                case STAGENAME.STAGE1_3:
                    SceneManager.LoadScene("1-3");


                    break;

                case STAGENAME.STAGE1_4:

                    SceneManager.LoadScene("1-4");

                    break;

                case STAGENAME.STAGE1_5:

                    break;

                case STAGENAME.TOMAP2:

                    // �X�e�[�W�Q��
                    stageName = STAGENAME.STAGE2_1;

                    break;

                case STAGENAME.BACKTOMAP1:

                    //  �X�e�[�W�P��
                    stageName = STAGENAME.STAGE1_1;

                    break;

                case STAGENAME.STAGE2_1:

                    SceneManager.LoadScene("2-1");

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
                    stageName = STAGENAME.STAGE3_1;

                    break;

                case STAGENAME.BACKTOMAP2:

                    //  �X�e�[�W�Q��
                    stageName = STAGENAME.STAGE2_1;

                    break;

                case STAGENAME.STAGE3_1:

                    SceneManager.LoadScene("3-1");
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
                    stageName = STAGENAME.STAGE4_1;

                    break;

                case STAGENAME.BACKTOMAP3:

                    //  �X�e�[�W�R��
                    stageName = STAGENAME.STAGE3_1;

                    break;

                case STAGENAME.STAGE4_1:
                    SceneManager.LoadScene("4-1");


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
                    stageName = STAGENAME.STAGE5_1;

                    break;
                    
                case STAGENAME.BACKTOMAP4:

                    //  �X�e�[�W�S��
                    stageName = STAGENAME.STAGE4_1;

                    break;

                case STAGENAME.STAGE5_1:

                    SceneManager.LoadScene("5-1");

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
}
