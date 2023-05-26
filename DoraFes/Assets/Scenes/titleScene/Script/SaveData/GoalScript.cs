using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public SaveData saveData;

    //Playerタグが接触するとセーブ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainPlayer"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            saveData.SaveProgress(currentSceneName);
        }
    }
}
