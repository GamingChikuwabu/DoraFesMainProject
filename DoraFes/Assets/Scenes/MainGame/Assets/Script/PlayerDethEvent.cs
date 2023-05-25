using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDethEvent : MonoBehaviour
{
    Rigidbody rig; 
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            rig.AddForce(new Vector3(0.0f, 0.0f, 0.0f),ForceMode.Impulse);
        }
    }
}
