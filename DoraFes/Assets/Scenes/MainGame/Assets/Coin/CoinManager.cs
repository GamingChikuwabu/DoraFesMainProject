using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // サウンドリソース
    [Header("コイン獲得時のSE")]
    [SerializeReference] private AudioClip sound1;
    AudioSource audioSource;
    // コインの取得フラグ
    private bool _isSound = false;
    public bool isSound { get { return _isSound; } set { _isSound = value; } }

    void Start()
    {
        // Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        // コインを取得したか？
        if (isSound)
        {
            // コイン取得SEを再生
            audioSource.PlayOneShot(sound1);
            isSound = false;
        }
    }
}
