using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatusManager : MonoBehaviour
{
    [SerializeField] GameObject efect;
    [Header("フィーバーゲージ")]
    [SerializeField]
    private float _FeverGauge = 0;

    [Header("フィーバーゲージの上がり具合")]
    [SerializeField]
    private float _FeverGaugeUpSpeed = 1;

    [Header("フィーバーの長さ")]
    [SerializeField]
    private float FeaverTimeLange = 10;

    [Header("コイン一枚のゲージの上がり幅")]
    [SerializeField]
    private float GaugeSpeedUp2Coin = 1.0f;

    CoinManager Cm;
    UIFeaverGauge UIGuage;
    BGMManager BgmManager;

    float stack = 0;
    bool feaver = false;

    public bool IsFever
    { 
        get { 
            if (_FeverGauge > 100) 
            {
                efect.SetActive(true);
                return true; 
            } 
            else 
            {
                efect.SetActive(false);
                return false; 
            } 
        }
    }

    public float FeverGaugeUpSpeed
    {
        get
        {
            return _FeverGaugeUpSpeed;
        }
        set
        {
            if(value > 100)
            {
                _FeverGaugeUpSpeed = 100; 
            }
            else
            {
                _FeverGaugeUpSpeed = value;
            }
        }
    }

    public void ResetFlg()
    {
        _FeverGauge = 0;
    }

    public float FeaverGauge
    {
        get { return _FeverGauge;}
    }

    // Start is called before the first frame update
    void Start()
    {
        Cm = GetComponent<CoinManager>();
        UIGuage = GameObject.Find("GaugeFrame").GetComponent<UIFeaverGauge>();
        BgmManager = GetComponent<BGMManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_FeverGauge >= 100)
        {
            if(!feaver)
            {
                BgmManager.SetBGM(BGMManager.Bgm.Fever);
                feaver = true;
            }
            stack += Time.deltaTime;
            if(stack >= FeaverTimeLange)
            {
                feaver = false;
                BgmManager.SetBGM(BGMManager.Bgm.Normal);
                stack = 0;
                _FeverGauge = 0;
                UIGuage.GaugeReset();
            }
        }
        else
        {
            _FeverGauge += _FeverGaugeUpSpeed * Time.deltaTime + (Cm.countCoin * GaugeSpeedUp2Coin) * Time.deltaTime;
        }
    }
}
