using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // ���[�h�ς݂̃V�[�������i�[���郊�X�g
    private List<string> loadedScenes = new List<string>();
    // UI���i�[
    GameObject canvas;

    private void Start()
    {
        // �V�[���Ԃŋ��L���邽�߁A���̃I�u�W�F�N�g��j�����Ȃ�
        // DontDestroyOnLoad(gameObject);

        // UI�̏K��
        canvas = GameObject.Find("SceneManager_Canvas");
    }

    // �w�肳�ꂽ�V�[�������[�h���郁�\�b�h
    public void LoadScene(string sceneName)
    {
        if (!loadedScenes.Contains(sceneName))  // ���Ƀ��[�h����Ă��Ȃ��ꍇ
        {
            // UI���A�N�e�B�u��
            canvas.SetActive(false);

            // �w�肳�ꂽ�V�[����ǉ��Ń��[�h
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            loadedScenes.Add(sceneName);  // ���[�h�ς݃��X�g�ɒǉ�
        }
    }

    // �w�肳�ꂽ�V�[�����A�����[�h���郁�\�b�h
    public void UnloadScene(string sceneName)
    {
        if (loadedScenes.Contains(sceneName))  // ���[�h����Ă���ꍇ
        {
            // �w�肳�ꂽ�V�[����񓯊��ŃA�����[�h
            SceneManager.UnloadSceneAsync(sceneName);
            loadedScenes.Remove(sceneName);  // ���[�h�ς݃��X�g����폜
        }
    }
}