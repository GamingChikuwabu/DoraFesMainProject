using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgmClip;

    private void Start()
    {
        audioSource.clip = bgmClip;
        audioSource.Play();
    }
}