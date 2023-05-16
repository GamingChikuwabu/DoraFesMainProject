using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //���[�h��ʂ�\�����鎞��
    [SerializeField] private float LoadingTime;

    //���[�h�V�[���̃V�[����
    private string LoadName = "LoadScene";

    //���ɑJ�ڂ���V�[���̃V�[����
    private string NextLoadName;

    // Start is called before the first frame update
    void Start()
    {
        NextLoadName = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(NextLoadName != "")
        {
            if (SceneManager.GetActiveScene().name != "LoadScene")
            {
                SceneManager.LoadScene(LoadName);
            }
        }

        if(SceneManager.GetActiveScene().name == "LoadScene")
        {
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
