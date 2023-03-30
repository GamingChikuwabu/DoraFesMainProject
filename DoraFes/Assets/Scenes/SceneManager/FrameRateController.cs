using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    void Start()
    {
        //60FPSÇ…ê›íË
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // Debug.Log(Time.deltaTime);
    }
}
