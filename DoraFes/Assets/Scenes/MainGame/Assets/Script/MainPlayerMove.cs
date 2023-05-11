using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMove : MonoBehaviour
{
    //�v���C���[�̍��E�ړ��̗�
    public float PlayerMovePower = 3;
    //�ړ��̌�����
    public float Decelerationrate = 0.1f;

    [Header("�d�͂ւ̉e���x")]
    [SerializeField]
    private float affectGravity = 2.0f;

    private float RetuerPlayerMovePower = 0;
    //���̃I�u�W�F�N�g��Rigidbody
    Rigidbody rig;
    LandMarkMove landMark;

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
        landMark = GameObject.FindGameObjectWithTag("LandMark").GetComponent<LandMarkMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector3(-PlayerMovePower, rig.velocity.y, landMark.LandMarkSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector3(PlayerMovePower, rig.velocity.y, landMark.LandMarkSpeed);
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x * Decelerationrate, rig.velocity.y, landMark.LandMarkSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !Isjump)
        {
            rig.AddForce(new Vector3(0.0f, jumpPouwer, 0.0f), ForceMode.Impulse);
            _Isjump = true;
        }

         
    }

    private void OnCollisionEnter(Collision collision)
    {
        _Isjump = false;
    }
}
