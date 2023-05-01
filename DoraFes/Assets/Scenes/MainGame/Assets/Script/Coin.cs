using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("コインが消滅するまでの時間")]
    [SerializeField] private float dethTimer = 1.0f;

    [Header("コイン獲得時のSE")]
    [SerializeReference] private AudioClip sound1;
    AudioSource audioSource;

    //Renderer targetRenderer;

    private void Start()
    {
        // Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sound1);
            // 特定のオブジェクトとの当たり判定が発生した場合の処理
            Destroy(gameObject, dethTimer);
        }
    }

    //Invoke("uuuu", 4);
    //void uuuu()
    //{
    //    audioSource.PlayOneShot(sound1);
    //}
}
