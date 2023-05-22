using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponePlayer : MonoBehaviour
{
    private FormationManager FM;
    public GameObject Player;

    private void Start()
    {
        FM = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<FormationManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainPlayer")
        {
            GameObject newGameObject = Instantiate(Player.gameObject, other.transform.position, Quaternion.identity);
            Rigidbody rig = newGameObject.GetComponent<Rigidbody>();

            rig.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);

            FM.NumMandragara++;

            newGameObject.GetComponent<PlayerMove>().SetLandmark(other.gameObject,new Vector3(0.0f,0.0f,FM.LandmarkToChar));

            Destroy(gameObject);

        }
    }
}
