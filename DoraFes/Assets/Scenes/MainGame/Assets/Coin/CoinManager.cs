using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // �T�E���h���\�[�X
    [Header("�R�C���l������SE")]
    [SerializeReference] private AudioClip sound1;
    AudioSource audioSource;
    // �R�C���̎擾�t���O
    private bool _isSound = false;
    public bool isSound { get { return _isSound; } set { _isSound = value; } }

    void Start()
    {
        // Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        // �R�C�����擾�������H
        if (isSound)
        {
            // �R�C���擾SE���Đ�
            audioSource.PlayOneShot(sound1);
            isSound = false;
        }
    }
}
