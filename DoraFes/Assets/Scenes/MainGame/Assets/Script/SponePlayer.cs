using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponePlayer : MonoBehaviour
{
    private FormationManager FM;
    private void Start()
    {
        FM = GameObject.FindGameObjectWithTag("LandMark").GetComponent<FormationManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject newGameObject = Instantiate(other.gameObject, other.transform.position, Quaternion.identity);
            Rigidbody rig = newGameObject.GetComponent<Rigidbody>();

            rig.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);

            newGameObject.GetComponent<PlayerMove>().SetLandmark(other.gameObject,new Vector3(0.0f,0.0f,FM.LandmarkToChar));

            Destroy(gameObject);
        }
    }
}
