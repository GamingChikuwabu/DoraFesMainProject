using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SponePlayer : MonoBehaviour
{
    private FormationManager FM;
    public GameObject Player;
    public int LineNum  = 3;
    private AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        FM = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<FormationManager>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainPlayer")
        {
            source.PlayOneShot(clip);
            GameObject newGameObject = Instantiate(Player.gameObject, other.transform.position, Quaternion.identity);
            Rigidbody rig = newGameObject.GetComponent<Rigidbody>();

            rig.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);

            FM.NumMandragara++;

            float temppos =0;

            switch(Random.Range(1,3))
            {    
                case 1:
                    temppos = -1.0f;
                    break;
                case 2:
                    temppos = 0.0f;
                    break;
                case 3:
                    temppos = 1.0f;
                    break;
            }

            newGameObject.GetComponent<PlayerMove>().SetLandmark(other.gameObject,new Vector3(temppos, 0.0f,FM.LandmarkToChar));

            Destroy(gameObject);
        }
    }
}
