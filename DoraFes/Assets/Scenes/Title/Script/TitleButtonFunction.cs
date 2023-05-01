using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonFunction : MonoBehaviour
{
    [SerializeField] private SaveData saveData;

    public void OnNewGameButtonClicked()
    {
        if (PlayerPrefs.HasKey("LastCompletedScene"))
        {
            // セーブデータがある場合、ダイアログ表示や削除の確認を行う。
            // この例では、削除を確認したと仮定しています。
            saveData.ResetProgress();
        }

        // 最初のステージシーンをロード（1-1と仮定）
        SceneManager.LoadScene("StageSelect");
    }

    public void OnContinueButtonClicked()
    {
        if (saveData.HasSaveData())
        {
            saveData.LoadProgress();
            string lastCompletedScene = saveData.lastCompletedScene;

             string[] splitSceneName = lastCompletedScene.Split('-');
             int chapterNumber = int.Parse(splitSceneName[0]);
             int stageNumber = int.Parse(splitSceneName[1]);
             stageNumber++;

             string nextSceneName = $"{chapterNumber}-{stageNumber}";
             SceneManager.LoadScene(nextSceneName);
        }
        else
        {
             Debug.LogWarning("No save data found. Start a new game instead.");
        }
    }

    public void OnQuitButtonClicked()
    {
        // アプリケーションを終了する
        Application.Quit();
    }
}
