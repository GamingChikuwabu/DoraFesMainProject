using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMove : MonoBehaviour
{
    private float YOffset;
    Rigidbody rig;
    MainPlayerMove MPM;
    float LerpVal = 1.0f;
    Vector3 oldvec;
    Vector3 startvec;
    DethEvent dethEvent;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();

        MPM = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<MainPlayerMove>();

        YOffset = transform.position.y - MPM.transform.position.y;

        oldvec = MPM.NewPlayerPos;

        dethEvent = MPM.gameObject.GetComponent<DethEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dethEvent.IsDamage == false)
        {
            //前に進むスピード
            rig.velocity = new Vector3(0.0f, 0.0f, MPM.Fowardvelocity);
            if (oldvec.x != MPM.NewPlayerPos.x)
            {
                LerpVal = 0.0f;
                startvec = transform.position;
                oldvec = MPM.NewPlayerPos;
            }

            float temp = Mathf.Lerp(startvec.y, MPM.NewPlayerPos.y + YOffset, LerpVal);
            LerpVal += 0.01f;
            if (LerpVal >= 1.0f)
            {
                LerpVal = 1.0f;
            }

            transform.position = new Vector3(transform.position.x, temp, transform.position.z);
        }
        else
        {
            rig.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
