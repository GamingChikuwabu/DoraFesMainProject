using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageNameText;

    // Start is called before the first frame update
    void Start()
    {
        // 初めに選ばれているステージ名
        stageNameText.text = "MAP1";
    }

    // Update is called once per frame
    void Update()
    {
        // StageSelectスプリクトから取得し代入
        StageSelect.STAGENAME stageNo = StageSelect.StageName;

        // 選択中のステージ名に変更
        switch(stageNo)
        {
            case StageSelect.STAGENAME.MAP1:

                stageNameText.text = "forest";

                break;

            case StageSelect.STAGENAME.MAP2:

                stageNameText.text = "jungle";

                break;

            case StageSelect.STAGENAME.MAP3:

                stageNameText.text = "desert";

                break;

            case StageSelect.STAGENAME.MAP4:

                stageNameText.text = "bridge";

                break;

            case StageSelect.STAGENAME.MAP5:

                stageNameText.text = "neon";

                break;


            case StageSelect.STAGENAME.STAGE1_1:

                stageNameText.text = "1_1";

                break;

            case StageSelect.STAGENAME.STAGE1_2:

                stageNameText.text = "1_2";

                break;

            case StageSelect.STAGENAME.STAGE1_3:

                stageNameText.text = "1_3";

                break;

            case StageSelect.STAGENAME.STAGE1_4:

                stageNameText.text = "1_4";

                break;

            case StageSelect.STAGENAME.STAGE1_5:

                stageNameText.text = "1_5";

                break;

            case StageSelect.STAGENAME.TOMAP2:

                stageNameText.text = "ToMap";

                break;

            case StageSelect.STAGENAME.BACKTOMAP1:

                stageNameText.text = "BackToMap";

                break;

            case StageSelect.STAGENAME.STAGE2_1:

                stageNameText.text = "2_1";

                break;

            case StageSelect.STAGENAME.STAGE2_2:

                stageNameText.text = "2_2";

                break;

            case StageSelect.STAGENAME.STAGE2_3:

                stageNameText.text = "2_3";

                break;

            case StageSelect.STAGENAME.STAGE2_4:

                stageNameText.text = "2_4";

                break;

            case StageSelect.STAGENAME.STAGE2_5:

                stageNameText.text = "2_5";

                break;

            case StageSelect.STAGENAME.TOMAP3:

                stageNameText.text = "ToMap";

                break;

            case StageSelect.STAGENAME.BACKTOMAP2:

                stageNameText.text = "BackToMap";

                break;

            case StageSelect.STAGENAME.STAGE3_1:

                stageNameText.text = "3_1";

                break;

            case StageSelect.STAGENAME.STAGE3_2:

                stageNameText.text = "3_2";

                break;

            case StageSelect.STAGENAME.STAGE3_3:

                stageNameText.text = "3_3";

                break;

            case StageSelect.STAGENAME.STAGE3_4:

                stageNameText.text = "3_4";

                break;

            case StageSelect.STAGENAME.STAGE3_5:

                stageNameText.text = "3_5";

                break;

            case StageSelect.STAGENAME.TOMAP4:

                stageNameText.text = "ToMap";

                break;

            case StageSelect.STAGENAME.BACKTOMAP3:

                stageNameText.text = "BackToMap";

                break;

            case StageSelect.STAGENAME.STAGE4_1:

                stageNameText.text = "4_1";

                break;

            case StageSelect.STAGENAME.STAGE4_2:

                stageNameText.text = "4_2";

                break;

            case StageSelect.STAGENAME.STAGE4_3:

                stageNameText.text = "4_3";

                break;

            case StageSelect.STAGENAME.STAGE4_4:

                stageNameText.text = "4_4";

                break;

            case StageSelect.STAGENAME.STAGE4_5:

                stageNameText.text = "4_5";

                break;

            case StageSelect.STAGENAME.TOMAP5:

                stageNameText.text = "ToMap";

                break;

            case StageSelect.STAGENAME.BACKTOMAP4:

                stageNameText.text = "BackToMap";

                break;

            case StageSelect.STAGENAME.STAGE5_1:

                stageNameText.text = "5_1";

                break;

            case StageSelect.STAGENAME.STAGE5_2:

                stageNameText.text = "5_2";

                break;

            case StageSelect.STAGENAME.STAGE5_3:

                stageNameText.text = "5_3";

                break;

            case StageSelect.STAGENAME.STAGE5_4:

                stageNameText.text = "5_4";

                break;

            case StageSelect.STAGENAME.STAGE5_5:

                stageNameText.text = "5_5";

                break;
        }
    }
}
