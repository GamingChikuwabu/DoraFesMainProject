using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class BGMManager : MonoBehaviour
{
    public enum Bgm
    {
        Fever,
        Normal
    }
    public AudioClip NormalBGM;
    public AudioClip FeaverBGM;
    private AudioSource source;
    private float _time;

    public float PlayTime
    {
        get { return _time;}
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = NormalBGM;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
    }

    public void SetBGM(Bgm bgm)
    {
        if(bgm == Bgm.Fever)
        {
            source.clip = FeaverBGM;
            source.time = 0.0f;
            source.Play();
        }
        else
        {
            source.clip = NormalBGM;
            source.time = _time;
            source.Play();
        }
    }
}
