using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public enum STAGENAME
    {
        // マップ選択
        MAPMIN,
        MAP1,
        MAP2,
        MAP3,
        MAP4,
        MAP5,
        MAPMAX,
        // ステージ１
        STAGE1MIN,
        STAGE1_1,
        STAGE1_2,
        STAGE1_3,
        STAGE1_4,
        STAGE1_5,
        TOMAP2,
        STAGE1MAX,
        //ステージ２
        STAGE2MIN,
        BACKTOMAP1,
        STAGE2_1,
        STAGE2_2,
        STAGE2_3,
        STAGE2_4,
        STAGE2_5,
        TOMAP3,
        STAGE2MAX,
        //ステージ３
        STAGE3MIN,
        BACKTOMAP2,
        STAGE3_1,
        STAGE3_2,
        STAGE3_3,
        STAGE3_4,
        STAGE3_5,
        TOMAP4,
        STAGE3MAX,
        //ステージ４
        STAGE4MIN,
        BACKTOMAP3,
        STAGE4_1,
        STAGE4_2,
        STAGE4_3,
        STAGE4_4,
        STAGE4_5,
        TOMAP5,
        STAGE4MAX,
        //ステージ５
        STAGE5MIN,
        BACKTOMAP4,
        STAGE5_1,
        STAGE5_2,
        STAGE5_3,
        STAGE5_4,
        STAGE5_5,
        STAGE5MAX,
    }

    // 選択中のステージ
    private static STAGENAME stageName;

    public static STAGENAME StageName
    {
        get { return stageName; }
        set { stageName = value; }
    }

    // マップの状態
    private static STAGENAME mapState = STAGENAME.MAP1;

    public static STAGENAME MapState
    {
        get { return mapState; }
        set { mapState = value; }
    }

    //  選択できるステージ
    private static STAGENAME clearStage = STAGENAME.STAGE5_1;

    public static STAGENAME ClearStage
    {
        get { return clearStage; }
        set { clearStage = value; }
    }

    // 傾けているかどうか
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
        // 初めに選ばれているステージ
        stageName = STAGENAME.MAP1;

        stickInputTriggered = false;

        stagenumUI = GameObject.Find("StageNum").GetComponent<StageNum>();
        worldnumUI = GameObject.Find("WorldNum").GetComponent<StageNum>();
        
        
    }

    void Update()
    {
        


        // FadeController クラスのインスタンスを取得する
        MapFade fadeController = GameObject.FindObjectOfType<MapFade>();
        // フェード中は処理できない
        if (fadeController.IsFading)
        {
            return;
        }

        


        // マップの状態を変化
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


        // 左スティックの水平方向の入力を取得
        float leftStickInput = Input.GetAxisRaw("L_Stick_Horizontal");

        // すでに傾けているか
        if ((leftStickInput > 0.1f) && (!stickInputTriggered)  || (Input.GetKeyDown(KeyCode.D))) // 右に倒した場合
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

                    // マップが選択できるか
                    if (stageName <= mapState)
                    {
                        // SEの再生を行う
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
           
            // ステージが選択できるかどうか
            if (stageName <= clearStage)
            {
                // SEの再生を行う
                audioSourceSE1.Play();
            }
            else
            {
                stageName -= 1;
                stageNumber--;
                stagenumUI.ChangeNumber(stageNumber);
            }

            
            // ステージが選択できない場合
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


        else if (leftStickInput < -0.1f  && !stickInputTriggered || (Input.GetKeyDown(KeyCode.A))) // 左に倒した場合
        {
            // 傾けている状態に
            stickInputTriggered = true;

            stageName -= 1;

            stageNumber--;
            if (stageNumber == 0)
            {
                stageNumber = 1;
            }
            stagenumUI.ChangeNumber(stageNumber);

            // SEの再生を行う
            audioSourceSE1.Play();

           
            // ステージが選択できない場合
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
            // スティックが倒されていない場合は、トリガーを解除
            stickInputTriggered = false;
        }

        // 選択中のステージへ
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
        {
            // SEの再生を行う
            audioSourceSE2.Play();

            // コルーチンを開始する
            StartCoroutine(WaitForSE(audioSourceSE2));

            stageNumber = 1;
            stagenumUI.ChangeNumber(stageNumber);
        }
    }

    // SEの再生が終わったら、シーン遷移する
    IEnumerator WaitForSE(AudioSource audioSource)
    {
        // SEの再生が終わるまで待機する
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

                // ステージ２へ
                WorldNumber = 2;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE2_1;

                break;

            case STAGENAME.BACKTOMAP1:

                //  ステージ１へ
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

                // ステージ３へ
                WorldNumber = 3;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE3_1;

                break;

            case STAGENAME.BACKTOMAP2:

                //  ステージ２へ
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

                // ステージ４へ
                WorldNumber = 4;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE4_1;

                break;

            case STAGENAME.BACKTOMAP3:

                //  ステージ３へ
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

                // ステージ５へ
                WorldNumber = 5;
                worldnumUI.ChangeWorld(WorldNumber);
                stageName = STAGENAME.STAGE5_1;

                break;

            case STAGENAME.BACKTOMAP4:

                //  ステージ４へ
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
