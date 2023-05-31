using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour
{
    //リトライするシーン名を取ってくる
    private GameObject RetrySceneObject;
    private SetSceneName SNS;

    public  enum STAGENAME
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

    private bool isFade;

    // Start is called before the first frame update
    void Start()
    {
        // 初めに選ばれているステージ
        stageName = STAGENAME.MAP1;

        //リトライするシーン名を取ってくる
        RetrySceneObject = GameObject.Find("RetryScene");
        SNS = RetrySceneObject.GetComponent<SetSceneName>();
    }

    // Update is called once per frame
    void Update()
    {
        MapFade fadeController = GameObject.FindObjectOfType<MapFade>(); // FadeController クラスのインスタンスを取得する
        if (fadeController.IsFading)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            stageName += 1;

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            stageName -= 1;

            // ステージが選択できない場合
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

        // 選択中のステージへ
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

                    // ステージ２へ
                    stageName = STAGENAME.STAGE2_1;

                    break;

                case STAGENAME.BACKTOMAP1:

                    //  ステージ１へ
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

                    // ステージ３へ
                    stageName = STAGENAME.STAGE3_1;

                    break;

                case STAGENAME.BACKTOMAP2:

                    //  ステージ２へ
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

                    // ステージ４へ
                    stageName = STAGENAME.STAGE4_1;

                    break;

                case STAGENAME.BACKTOMAP3:

                    //  ステージ３へ
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

                    // ステージ５へ
                    stageName = STAGENAME.STAGE5_1;

                    break;
                    
                case STAGENAME.BACKTOMAP4:

                    //  ステージ４へ
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
