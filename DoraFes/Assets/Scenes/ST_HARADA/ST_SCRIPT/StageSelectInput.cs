using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectInput : MonoBehaviour
{
    public enum IsInputBottom
    {
        NONE,       // ���͂Ȃ�
        STICK_H_P,  // �X�e�B�b�N�������i���j
        STICK_H_N,  // �X�e�B�b�N�������i���j
        STICK_V_P,  // �X�e�B�b�N�c�����i���j
        STICK_V_N,  // �X�e�B�b�N�c�����i���j
        A,          // A
        B,          // B
        L,          // L
        R,          // R
    }

    // ���t���[���œ��͂��ꂽ�{�^�����i�[
    [System.NonSerialized] public IsInputBottom isBottom = IsInputBottom.NONE;
    // ���t���[���ŃX�e�B�b�N�̓��͂������������ʂ���
    private bool isInputStick = false;

    [Header("���͂̊Ԋu")]
    public float interval = 0.3f;
    [System.NonSerialized] public float intervalCount = 0f;   // ���͂���Ă���̌o�ߎ���

    // ���͏��̍X�V
    public void CheakInput()
    {
        // �{�^�����͏󋵂�������
        isBottom = IsInputBottom.NONE;

        // �Ō�ɓ��͂���Ă���K�莞�Ԉȉ�
        if (Time.time - intervalCount < interval) return;

        // �L�[�̓��͏󋵂��i�[
        CheakInputKey();

        // �R���g���[���[�̓��͏󋵂��X�V
        CheakInputStick();  // �X�e�B�b�N�̓��͂��`�F�b�N

        // �D�揇�Ń{�^���̓��͏����i�[
        if (isInputStick) {}
        else if (Input.GetKey("joystick button 0")) isBottom = IsInputBottom.A;
        else if (Input.GetKey("joystick button 1")) isBottom = IsInputBottom.B;
        else if (Input.GetKey("joystick button 4")) isBottom = IsInputBottom.L;
        else if (Input.GetKey("joystick button 5")) isBottom = IsInputBottom.R;

        // ���͂��ꂽ�������i�[
        if (isBottom != IsInputBottom.NONE)
        {
            intervalCount = Time.time;
        }
    }

    // �X�e�B�b�N�̓��͗L�����`�F�b�N����֐�
    void CheakInputStick()
    {
        // ���͏󋵂�������
        isInputStick = false;

        float horizontalInput;  // �������̓���
        float verticalInput;    // �c�����̓���
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // ���t���[���œ��͂��ꂽ���H
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            isInputStick = true;

            // �������ւ̌X�����傫��
            if (Mathf.Abs(horizontalInput) - Mathf.Abs(verticalInput) >= 0)
            {
                // �������ɓ|����Ă���̂��H
                if (horizontalInput >= 0) isBottom = IsInputBottom.STICK_H_P;
                else isBottom = IsInputBottom.STICK_H_N;
            }
            // �c�����ւ̌X�����傫��
            else
            {
                // �������ɓ|����Ă���̂��H
                if (verticalInput >= 0) isBottom = IsInputBottom.STICK_V_P;
                else isBottom = IsInputBottom.STICK_V_N;
            }
        }
    }

    // �L�[�{�[�h�̓��͏���
    void CheakInputKey()
    {
        if (Input.GetKeyDown(KeyCode.D)) isBottom = IsInputBottom.STICK_H_P;
        else if (Input.GetKeyDown(KeyCode.A)) isBottom = IsInputBottom.STICK_H_N;
        else if (Input.GetKeyDown(KeyCode.W)) isBottom = IsInputBottom.STICK_V_P;
        else if (Input.GetKeyDown(KeyCode.S)) isBottom = IsInputBottom.STICK_V_N;
        else if (Input.GetKeyDown(KeyCode.Return)) isBottom = IsInputBottom.A;
        else if (Input.GetKeyDown(KeyCode.B)) isBottom = IsInputBottom.B;
        else if (Input.GetKeyDown(KeyCode.Q)) isBottom = IsInputBottom.L;
        else if (Input.GetKeyDown(KeyCode.E)) isBottom = IsInputBottom.R;
    }
}