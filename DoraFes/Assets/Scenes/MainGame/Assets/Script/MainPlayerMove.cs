using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMove : MonoBehaviour
{
    //�v���C���[�̍��E�ړ��̗�
    public float PlayerMovePower = 3;
    //�ړ��̌�����
    public float Decelerationrate = 0.1f;

    [Header("�^���d��")]
    [SerializeField]
    private float Gravity = 2.0f;

    [Header("�W�����v��")]
    public float jumpPouwer = 45.0f;

    private float stackjumpPouwer;


    //���̃I�u�W�F�N�g��Rigidbody
    Rigidbody rig;
    LandMarkMove landMark;

    bool Leftmove = true;
    bool Rightmove = true;

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
        if (Input.GetKey(KeyCode.A) && Leftmove)
        {
            rig.velocity = new Vector3(-PlayerMovePower, rig.velocity.y, landMark.LandMarkSpeed);
        }
        else if (Input.GetKey(KeyCode.D) && Rightmove)
        {
            rig.velocity = new Vector3(PlayerMovePower, rig.velocity.y, landMark.LandMarkSpeed);
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x * Decelerationrate, rig.velocity.y, landMark.LandMarkSpeed);
        }


        if (Input.GetKeyDown(KeyCode.Space) && !Isjump)
        {
            _Isjump = true;
            stackjumpPouwer = jumpPouwer;
        }

        if(_Isjump) 
        {
            stackjumpPouwer -= Gravity * Time.deltaTime;
            rig.velocity = new(rig.velocity.x, stackjumpPouwer, rig.velocity.z);
        }

        Vector3 tempvec = new Vector3(transform.position.x, transform.position.y, landMark.LandMarkToCharPos);
        Vector3 latevec =  tempvec - transform.position;
        rig.AddForce(latevec * 300);

        Debug.Log(latevec.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�㉺�����̃u���b�N�ɓ������Ă���ꍇ
        if (Physics.Raycast(transform.position, new(0.0f, 1.0f, 0.0f), 10.0f)|| Physics.Raycast(transform.position, new(0.0f, -1.0f, 0.0f), 10.0f))
        {
            stackjumpPouwer = 0;
        }

        _Isjump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InvWall")
        {
            rig.velocity = new(0.0f, rig.velocity.y, rig.velocity.z);
            if (Physics.Raycast(transform.position, new(1.0f, 0.0f, 0.0f), 10.0f))
            {
                Rightmove = false;
                Leftmove = true;
            }
            else if (Physics.Raycast(transform.position, new(-1.0f, 0.0f, 0.0f), 10.0f))
            {
                Rightmove = true;
                Leftmove = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rightmove = true;
        Leftmove = true;
    }
}
