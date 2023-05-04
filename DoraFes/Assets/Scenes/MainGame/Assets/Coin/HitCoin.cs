using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCoin : MonoBehaviour
{
    CoinManager coinManager = null;

    private void Start()
    {
        coinManager = GameObject.FindWithTag("LandMark").GetComponent<CoinManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinManager.isSound = true;
            Destroy(other.gameObject);
        }
    }
}
