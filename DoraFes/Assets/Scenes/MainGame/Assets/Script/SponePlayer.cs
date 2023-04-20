using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rig = Instantiate(other, other.transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rig.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);

            Destroy(gameObject);
        }
    }
}
