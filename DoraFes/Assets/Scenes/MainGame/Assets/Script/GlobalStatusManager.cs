using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatusManager : MonoBehaviour
{
    [Header("フィーバーゲージ")]
    [SerializeField]
    private float _FeverGauge = 0;

    [Header("フィーバーゲージの上がり具合")]
    [SerializeField]
    private float _FeverGaugeUpSpeed = 1;

    CoinManager manager;

    public float CoinSpeedManager = 0.01f;

    public bool IsFever

    { 
        get { 
            if (_FeverGauge > 100) 
            { 
                return true; 
            } 
            else 
            {
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

    public float FeverGauge
    {
        get { return _FeverGauge; }
    }

    public void ResetFlg()
    {
        _FeverGauge = 0;
    }

    private void FeverGaugeUpSpeedSetDefault()
    {
        FeverGaugeUpSpeed = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _FeverGauge += (_FeverGaugeUpSpeed + (manager.countCoin * CoinSpeedManager)) * Time.deltaTime;

        //Debug.Log((_FeverGaugeUpSpeed + (manager.countCoin * CoinSpeedManager)).ToString());
    }
}
