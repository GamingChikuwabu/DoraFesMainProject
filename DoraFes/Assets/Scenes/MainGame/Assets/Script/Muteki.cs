using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muteki : MonoBehaviour
{
    GlobalStatusManager gm;
    public AudioClip DethSE;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GlobalStatusManager>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gm.IsFever && other.gameObject.CompareTag("enemy"))
        {
            source.PlayOneShot(DethSE);
            if (transform.position.x < other.transform.position.x)
            {
                other.GetComponent<Rigidbody>().AddForce(10.0f, 20.0f, 10.0f, ForceMode.Impulse);
                other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 13.0f);
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce(-10.0f, 20.0f, 10.0f, ForceMode.Impulse);
                other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 13.0f);
            }

        }
    }
}
