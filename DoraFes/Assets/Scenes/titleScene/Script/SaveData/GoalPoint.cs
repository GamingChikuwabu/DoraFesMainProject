/// <summary>
/// GoalPoint スクリプトは、プレイヤーがゴールポイントに到達した際の処理を実行します。
/// ゴールに到達したとき、現在のシーン（ステージ）の進捗状況をセーブし、ステージセレクト画面に戻ります。
/// このスクリプトをゴールポイントのゲームオブジェクトにアタッチして使用します。
/// インスペクターウィンドウから、セーブデータ（SaveData）とステージセレクト画面のシーン名を設定してください。
/// </summary>

using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private SaveData saveData;
    [SerializeField] private string stageSelectSceneName = "StageSelect";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ReachGoalPoint();
        }
    }

    private void ReachGoalPoint()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        saveData.SaveProgress(currentSceneName);

        // ステージセレクト画面に戻る
        SceneManager.LoadScene(stageSelectSceneName);
    }
}
