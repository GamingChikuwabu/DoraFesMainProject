using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("�R�C�������ł���܂ł̎���")]
    [SerializeField] private float dethTimer = 1.0f;

    [Header("�R�C���l������SE")]
    [SerializeReference] private AudioClip sound1;
    AudioSource audioSource;

    //Renderer targetRenderer;

    private void Start()
    {
        // Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sound1);
            // ����̃I�u�W�F�N�g�Ƃ̓����蔻�肪���������ꍇ�̏���
            Destroy(gameObject, dethTimer);
        }
    }

    //Invoke("uuuu", 4);
    //void uuuu()
    //{
    //    audioSource.PlayOneShot(sound1);
    //}
}
