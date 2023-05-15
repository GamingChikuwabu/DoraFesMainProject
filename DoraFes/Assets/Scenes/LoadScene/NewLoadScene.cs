using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewLoadScene : MonoBehaviour
{
    public float loadingTime = 5f; // ���[�h��ʂ�\�����鎞��

    private void Start()
    {
        // ���[�h��ʂ�\������
        SceneManager.LoadSceneAsync("LoadScene", LoadSceneMode.Additive);
        // ���̃V�[���ɑJ�ڂ���R���[�`�����J�n����
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        // �w�肵�����Ԃ������[�h��ʂ�\������
        yield return new WaitForSeconds(loadingTime);

        // ���[�h��ʂ��폜����
        SceneManager.UnloadSceneAsync("LoadScene");

        // ���̃V�[���ɑJ�ڂ���
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes in build settings.");
        }
    }
}

