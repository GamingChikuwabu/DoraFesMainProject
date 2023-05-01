using System.Collections;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    [SerializeField] private Transform[] targets; // 追跡するオブジェクトのTransformを配列にする
    [SerializeField] private float distance = 5f; // カメラと追跡オブジェクトの距離
    private Transform target;  // 選択中のマップ
    private Quaternion initialRotation; // カメラの初期角度

    private MapFade fadeController; // フェードコントローラー

    private StageSelect.STAGENAME currentStage; // 現在のステージ

    void Start()
    {
        initialRotation = transform.rotation; // カメラの初期角度を保存する
        target = targets[0]; // 最初のターゲットを設定する
        fadeController = FindObjectOfType<MapFade>(); // FadeControllerを取得する

        currentStage = StageSelect.StageName; // 現在のステージを初期化する
    }

    void Update()
    {


        // 現在のステージを監視し、前回のステージと異なる場合にカメラを移動する
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
            // マップ１に移動
            case StageSelect.STAGENAME.STAGE1_1:

                if (target != targets[1])
                {
                    StartCoroutine(FadeAndMove(targets[1]));

                    target = targets[1];
                }

                break;

            // マップ２に移動
            case StageSelect.STAGENAME.STAGE2_1:

                if (target != targets[2])
                {
                    StartCoroutine(FadeAndMove(targets[2]));

                    target = targets[2];
                }
                break;

            // マップ３に移動
            case StageSelect.STAGENAME.STAGE3_1:
                if (target != targets[3])
                {
                    StartCoroutine(FadeAndMove(targets[3]));

                    target = targets[3];
                }
                break;

            // マップ４に移動
            case StageSelect.STAGENAME.STAGE4_1:
                if (target != targets[4])
                {
                    StartCoroutine(FadeAndMove(targets[4]));

                    target = targets[4];
                }
                break;

            // マップ５に移動
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
        fadeController.gameObject.SetActive(true); // フェード用のImageを有効にする

        yield return StartCoroutine(fadeController.FadeOut()); // フェードアウトする

        // カメラの位置と角度を初期化する
        transform.position = target.position - transform.forward * distance;
        transform.rotation = initialRotation;

        yield return StartCoroutine(fadeController.FadeIn()); // フェードインする

        fadeController.gameObject.SetActive(false); // フェード用のImageを無効にする

        // カメラをアクティブにする
        gameObject.SetActive(true);
    }

}
