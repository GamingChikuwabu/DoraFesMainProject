using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFeaverGauge : MonoBehaviour
{
    Image[] images;
    GlobalStatusManager Gsm;
    int arraynum;

    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            image.enabled = false;
        }
        Gsm = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<GlobalStatusManager>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        int temp = (int)(Gsm.FeaverGauge / 10.0f);
        
        if(temp <= 10)
        {
            images[temp].enabled = true;
        }
    }

    public void GaugeReset()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
    }
}
