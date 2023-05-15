using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkMove : MonoBehaviour
{ 
    //�ڕW�_�̐i�ރX�s�[�h
    public float LandMarkSpeed = 5;
    //���̃I�u�W�F�N�g��Rigidbody
    Rigidbody rig;

    [Header("�����h�}�[�N�ƃL�����N�^�[�̋���")]
    [SerializeField]
    private float _landMarkToCharOffset = 5;
    [Header("�J�����̏㉺�̒Ǐ]�X�s�[�h�ő�1")]
    [SerializeField]
    private float CameraLeepSpeed = 0.1f;


    public Vector3 OldPos;

    private float LeepPoint = 0; 

    public float jumpPouwer = 15.0f;

    private float _playerYPos;
    public float PlayerYPos
    {
        set { OldPos = new (0.0f,transform.position.y,0.0f);
            _playerYPos = value; 
            LeepPoint = 0; }
    }

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

        Vector3 tempVec = new Vector3(0.0f, _playerYPos, 0.0f) - transform.position;

        tempVec.z = 0.0f;
        tempVec.x = 0.0f;

        LeepPoint += CameraLeepSpeed;

        transform.position = new(transform.position.x, Vector3.Lerp(OldPos, new Vector3(0.0f, _playerYPos, 0.0f), LeepPoint).y, transform.position.z);
    }


}
