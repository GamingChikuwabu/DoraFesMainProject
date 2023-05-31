using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DethEvent : MonoBehaviour
{
    Rigidbody rig;
    public bool IsDamage = false;
    GlobalStatusManager GS;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        GS = GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy") && GS.IsFever == false)
        {
            rig.AddForce(new Vector3(0.0f, 30.0f, 0.0f), ForceMode.Impulse);
            IsDamage = true;

            Invoke("ChangeScene", 2.0f);
           
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
