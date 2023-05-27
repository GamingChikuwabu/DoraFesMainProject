using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpotLight : MonoBehaviour
{

    private bool isFever;

    //プレイヤーのGlobalStatusManagerスクリプトのisFeverを取得する変数
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        isFever = false;

        //Playerのスクリプトを取得する
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isFever = GSM.IsFever;

        if (isFever)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
