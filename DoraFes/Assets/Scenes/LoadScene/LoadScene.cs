using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //���[�h��ʂ�\�����鎞��
    [SerializeField] private float LoadingTime = 5.0f;

    //���[�h�V�[���̃V�[����
    private string LoadName = "LoadScene";

    //���ɑJ�ڂ���V�[���̃V�[����
    private string NextLoadName;

    //Invoke�𕡐���Ăяo���Ȃ����߂̕ϐ�
    private bool isSceneChanging = false;

    // Start is called before the first frame update
    void Start()
    {
        NextLoadName = "";
    }

    // Update is called once per frame
    void Update()
    {
        //NextLoadName���󗓂̂Ƃ�
        if(NextLoadName != "")
        {
            //���݂̃V�[������LoadScene����Ȃ��Ƃ�
            if (SceneManager.GetActiveScene().name != "LoadScene")
            {
                //���[�h��ʂ�\������
                SceneManager.LoadScene(LoadName);

                isSceneChanging = true;
            }
        }

        //���݂̃V�[������LoadScene�̂Ƃ�
        if(isSceneChanging && SceneManager.GetActiveScene().name == "LoadScene")
        {
            isSceneChanging = false;

            //�w�莞�Ԍ��ChangeScene�֐����Ăяo��
            Invoke("ChangeScene", LoadingTime);
        }
    }

    //�V�[�������[�h����֐�
    private void ChangeScene()
    {
        SceneManager.LoadScene(NextLoadName);
        NextLoadName = "";
    }

    //���ɑJ�ڂ���V�[�������Z�b�g����֐�
    public void SetLoadName(string a)
    {
        NextLoadName = a;
    }
    
}
