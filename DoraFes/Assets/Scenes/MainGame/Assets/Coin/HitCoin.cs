using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCoin : MonoBehaviour
{
    CoinManager coinManager = null;
    CoinNum coinUI;

    private void Start()
    {
        coinManager = GameObject.FindWithTag("MainPlayer").GetComponent<CoinManager>();
        coinUI = GameObject.Find("UI_CoinNum").GetComponent<CoinNum>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinManager.isSound = true;
            coinManager.countCoin++;
            coinUI.ChangeNumber(coinManager.countCoin);
            Destroy(other.gameObject);
        }
    }
}
