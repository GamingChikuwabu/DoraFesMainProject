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

    public void ResetFlg()
    {
        _FeverGauge = 0;
    }

    public float FeaverGauge
    {
        get { return _FeverGauge; }
    }

    private void FeverGaugeUpSpeedSetDefault()
    {
        FeverGaugeUpSpeed = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _FeverGauge += _FeverGaugeUpSpeed * Time.deltaTime;
    }
}
