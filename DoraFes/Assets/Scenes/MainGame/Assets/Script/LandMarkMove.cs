using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkMove : MonoBehaviour
{ 
    //目標点の進むスピード
    public float LandMarkSpeed = 5;
    //このオブジェクトのRigidbody
    Rigidbody rig;

    [Header("ランドマークとキャラクターの距離")]
    [SerializeField]
    private float _landMarkToCharOffset = 5;

    public float jumpPouwer = 15.0f;

    bool _Isjump = false;

    public bool Isjump
    {
        get { return _Isjump; }
    }

    public float LandMarkToCharPos
    {
        get { return transform.position.z - _landMarkToCharOffset;}
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
