using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    [Header("空の色")]
    [SerializeField]private Color skyColor = Color.blue;
    [Header("赤道の色")]
    [SerializeField] private Color equatorColor = Color.gray;
    [Header("地面の色")]
    [SerializeField] private Color groundColor = Color.green;

    [Header("空の色(フィーバー中)")]
    [SerializeField] private Color feverSkykyColor = Color.blue;
    [Header("赤道の色(フィーバー中)")]
    [SerializeField] private Color feverEquatorColor = Color.gray;
    [Header("地面の色(フィーバー中)")]
    [SerializeField] private Color feverGroundColor = Color.green;

    //フィーバー中かどうかを取得する変数
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
        //フィーバー中かどうかを取得する
        isFever = GSM.IsFever;

        if(isFever)
        {
            // RenderSettings の環境色を設定する
            RenderSettings.ambientSkyColor = feverSkykyColor;
            RenderSettings.ambientEquatorColor = feverEquatorColor;
            RenderSettings.ambientGroundColor = feverGroundColor;
        }
        else
        {
            // RenderSettings の環境色を設定する
            RenderSettings.ambientSkyColor = skyColor;
            RenderSettings.ambientEquatorColor = equatorColor;
            RenderSettings.ambientGroundColor = groundColor;
        }
        
    }
}
