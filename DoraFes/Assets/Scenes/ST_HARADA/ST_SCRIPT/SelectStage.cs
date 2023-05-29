using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour
{
    [Header("���[���h���̃I�u�W�F�N�g��n��")]
    [SerializeField] GameObject[] objStage;

    [Header("�Z�[�u�f�[�^��n��")]
    public SaveData saveData;

    [Header("UI��n��")]
    [SerializeField] GameObject[] objUI;

    int world;
    int stage;

    int selectWorld;

    void Start()
    {
        // �N���A�󋵂��i�[
        string act = saveData.GetString();

        if (act == null)
        {
            world = 1;
            stage = 1;
        }
        else
        {
            world = int.Parse(act.Substring(0, 1)); // ���[���h
            stage = int.Parse(act.Substring(2, 1)); // �X�e�[�W
        }
    }


    void Update()
    {
        
    }
}
