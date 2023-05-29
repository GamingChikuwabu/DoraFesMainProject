using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices;

public class TitleButtonFunction : MonoBehaviour
{
    [SerializeField] private SaveData saveData;
    [SerializeField] private AudioSource audioSource; // AudioSource component for playing sound
    [SerializeField] private AudioClip flipSound; // Sound of flipping book
    [SerializeField] private float animationDuration = 1f; // Duration of the animation
    [SerializeField] private RectTransform buttonRectTransform; // RectTransform of the button

    private GameObject LoadSceneObject;
    private LoadScene LS;

    void Start()
    {
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();
    }

    public void OnNewGameButtonClicked()
    {
        if (PlayerPrefs.HasKey("LastCompletedScene"))
        {
            saveData.ResetProgress();
        }

        // Play animation and sound
        PlayAnimationAndSound();

        // Load the scene after the animation
        //StartCoroutine(LoadSceneAfterDelay("1-1", animationDuration));
        LS.SetLoadName("StageSelect");
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

            // Play animation and sound
            PlayAnimationAndSound();

            // Load the scene after the animation
            StartCoroutine(LoadSceneAfterDelay(nextSceneName, animationDuration));
        }
        else
        {
            Debug.LogWarning("No save data found. Start a new game instead.");
        }
    }

    public void OnQuitButtonClicked()
    {
        // Play animation and sound
        PlayAnimationAndSound();

        // Quit the application after the animation
        StartCoroutine(QuitAfterDelay(animationDuration));
    }

    private void PlayAnimationAndSound()
{
    // Move the button upward and left, and fade out
    buttonRectTransform.DOAnchorPosY(buttonRectTransform.anchoredPosition.y + 500, animationDuration);
    buttonRectTransform.DOAnchorPosX(buttonRectTransform.anchoredPosition.x - 500, animationDuration);
    buttonRectTransform.GetComponent<Image>().DOFade(0, animationDuration);

    // Add rotation to simulate the effect of wind
    buttonRectTransform.DORotate(new Vector3(0, 0, -90), animationDuration);

    // Play flip sound
    audioSource.PlayOneShot(flipSound);
}

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
