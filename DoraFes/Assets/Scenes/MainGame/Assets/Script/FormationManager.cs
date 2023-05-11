using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    //現在のマンドラゴラの数
    private int _numMandoragara = 0;
    //隊列の一番最初のキャラとLandmarkの距離

    public float LandmarkToChar = -3;

    MandNum mandNum;

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
            mandNum.ChangeNumber(_numMandoragara);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        mandNum = GameObject.Find("UI_MandNum").GetComponent<MandNum>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
