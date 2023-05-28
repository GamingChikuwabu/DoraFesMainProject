using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSound : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    //フィーバー中かを判定する変数
    private bool isFever;
    private bool isSound;

    //プレイヤーのGlobalStatusManagerスクリプトのisFeverを取得する変数
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //Playerのスクリプトを取得する
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isFever = GSM.IsFever;

        if(isFever==false)
        {
            isSound = false;
        }

        if(isFever)
        {
            if (isSound == false)
            {
                audioSource.PlayOneShot(sound1);
                isSound = true;
            }
        }
        

    }
}
