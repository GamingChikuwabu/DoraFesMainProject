using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        // �R���g���[���[�̐������i���X�e�B�b�N�܂��͏\���L�[�j�̓��͂��擾
        horizontalInput = Input.GetAxis("Horizontal");

        // �R���g���[���[�̐������i���X�e�B�b�N�܂��͏\���L�[�j�̓��͂��擾
        verticalInput = Input.GetAxis("Vertical");
    }

    public float GetHorizontalInput()
    {
        return horizontalInput;
    }

    public float GetVerticalInput()
    {
        return verticalInput;
    }
}

