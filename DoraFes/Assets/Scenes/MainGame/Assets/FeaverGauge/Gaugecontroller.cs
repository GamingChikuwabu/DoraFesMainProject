using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaugecontroller : MonoBehaviour
{
    GameObject[] gameObjects;
    GlobalStatusManager gsm;
    Image[] image;
    public Color color;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gameObjects = GameObject.FindGameObjectsWithTag("Gauge");
        int i = 0;
        image = new Image[10];

        foreach(GameObject obj in gameObjects)
        {
            image[i] = obj.GetComponent<Image>();
            i++;
        }

        gsm = GameObject.FindGameObjectWithTag("LandMark").GetComponent<GlobalStatusManager>();
        if(gsm == null)
        {
            Debug.Log("erorr");
        }
    }

    // Update is called once per frame

    void Update()
    {
        int temp = (int)(gsm.FeverGauge / 10);
        if (image[temp].color.g == 1.0f)
        {
            image[temp].color = color;
        }
    }
}
