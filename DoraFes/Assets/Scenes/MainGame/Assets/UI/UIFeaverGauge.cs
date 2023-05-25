using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFeaverGauge : MonoBehaviour
{
    public Color color;
    GameObject[] obj;
    GlobalStatusManager Gsm;
    int arraynum;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectsWithTag("Gauge");
        Gsm = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Gsm.FeaverGauge / 5 == 0)
        {
            arraynum++;
            Debug.Log("a");
            obj[arraynum].GetComponent<Image>().color = color;
        }
    }
}
