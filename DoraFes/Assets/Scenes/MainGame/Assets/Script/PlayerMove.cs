using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameObject landmark;
    LandMarkMove LM;
    Rigidbody myrig;
    bool t = false;

    private void Start()
    {
        landmark = GameObject.Find("LandMark");
        LM = landmark.GetComponent<LandMarkMove>();
        myrig = GetComponent<Rigidbody>();
        if(!myrig)
        {
            Debug.Log("oioio");
        }
    }

    private void Update()
    {
        if (LM.GetMovePower() >= 0)
        {
       // myrig.AddForce(new Vector3(LM.GetMovePower(), myrig.velocity.y, myrig.velocity.z));
            myrig.velocity = new( LM.GetMovePower(), myrig.velocity.y, myrig.velocity.z);
        }
        Debug.Log(LM.GetMovePower().ToString());
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + LM.LandMarkSpeed);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //t = true;
            myrig.AddForce(new Vector3(0.0f,5.0f,0.0f),ForceMode.Impulse);
        }
        
    }

    private void FixedUpdate()
    {
        if(LM.GetMovePower() == 0)
        {
            gameObject.layer = 0;
            myrig.velocity = new Vector3(myrig.velocity.x, myrig.velocity.y,0.0f);
        }
        else
        {
            gameObject.layer = 3;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        t = false;
    }


}
