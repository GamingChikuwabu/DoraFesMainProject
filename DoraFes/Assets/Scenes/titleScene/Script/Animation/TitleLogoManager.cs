using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleLogoManager : MonoBehaviour
{
    public static TitleLogoManager Instance { get; private set; }
    
    //インスペクターから設定
    [SerializeField] private FadeController fadeController;
    [SerializeField] private TitleLogoAnimation titleLogoAnimation;

    [Header("BGM Settings")]
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioClip bgmClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        titleLogoAnimation.enabled = false;
    }

    public void PlayBGM()
    {
        bgmAudioSource.clip = bgmClip;
        bgmAudioSource.volume = 0; // 音量を初めて0に設定
        bgmAudioSource.Play();
        bgmAudioSource.DOFade(
            0.4f,   //音量
            2.8f);  //時間
            // 1秒かけて音量を0から1へクロスフェード
    }


    private void HandleFadeInComplete()
    {
        titleLogoAnimation.enabled = true;
        titleLogoAnimation.AnimateTitleLogo();
    }
}