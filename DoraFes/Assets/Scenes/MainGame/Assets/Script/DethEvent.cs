using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethEvent : MonoBehaviour
{
    Rigidbody rig;
    public bool IsDamage = false;

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
            Debug.Log("waaaaaaa");
            rig.AddForce(new Vector3(0.0f, 120.0f,120.0f),ForceMode.Impulse);
            IsDamage = true;
        }
    }
}
