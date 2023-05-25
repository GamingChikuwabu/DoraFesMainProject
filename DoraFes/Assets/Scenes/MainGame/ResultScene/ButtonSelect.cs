using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class ButtonSelect : MonoBehaviour
{
	Button Retry;
	Button Return;

	//�R���g���[���[�̎擾
	private GameObject ChangeSceneObject;
	private ControllerInput CI;

	//���g���C�{�^�����I������Ă��邩�ǂ���
	private bool isRetryBotton;

	void Start()
	{
		// �{�^���R���|�[�l���g�̎擾
		Retry = GameObject.Find("Retry").GetComponent<Button>();
		Return = GameObject.Find("Return").GetComponent<Button>();

		ChangeSceneObject = GameObject.Find("ChangeScene");
		CI = ChangeSceneObject.GetComponent<ControllerInput>();

		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		Retry.Select();
		isRetryBotton = true;
	}

    private void Update()
    {
        if (isRetryBotton == true)
        {
			//Retry.colors()
			if (CI.GetVerticalInput() > 0.0f)
			{
				isRetryBotton = false;
				Return.Select();
			}
		}
        else
        {
			if (CI.GetVerticalInput() < 0.0f)
			{
				isRetryBotton = true;
				Retry.Select();
			}
		}
        
    }


}
