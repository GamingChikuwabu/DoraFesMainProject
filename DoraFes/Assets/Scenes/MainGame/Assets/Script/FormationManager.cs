using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    //現在のマンドラゴラの数
    private int _numMandoragara = 0;
    //隊列の一番最初のキャラとLandmarkの距離
    
    public float LandmarkToChar = -3;

    //マンドラゴラの数の取得プロパティ
    public int NumMandragara
    {
        get
        {
            return _numMandoragara;
        }
        set
        {
            _numMandoragara = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //最初のマンドラゴラを増やす
        NumMandragara++;
        //最初のプレイヤーを増やす
        GameObject player =  GameObject.FindGameObjectWithTag("Player");
        if (player == null) 
        {
            Debug.Log("Playerが設置されていないかTagがPlayerのObjectがありません");
        }
        PlayerMove pm =  player.GetComponent<PlayerMove>();
        //ランドマークを探す
        GameObject landmerk = GameObject.FindGameObjectWithTag("LandMark");
        if (landmerk == null)
        {
            Debug.Log("LandMarkが設置されていないかTagがLandMarkのObjectがありません");
        }

        LandMarkMove landMarkMove = landmerk.GetComponent<LandMarkMove>();
        
        pm.SetLandmark(landmerk, new Vector3(0.0f, 0.0f, -landMarkMove.LandMarkSpeed + LandmarkToChar));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
