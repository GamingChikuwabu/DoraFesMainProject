using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkMove : MonoBehaviour
{ 
    //�ڕW�_�̐i�ރX�s�[�h
    public float LandMarkSpeed = 5;
    //���̃I�u�W�F�N�g��Rigidbody
    Rigidbody rig;

    public float jumpPouwer = 15.0f;

    bool _Isjump = false;

    public bool Isjump
    {
        get { return _Isjump; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, LandMarkSpeed);
        if (rig == null)
        {
            Debug.Log("non");
        }
    }
}
