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
            _Isjump = true;
            stackjumpPouwer = jumpPouwer;
        }

        if(_Isjump) 
        {
            stackjumpPouwer -= Gravity * Time.deltaTime;
            rig.velocity = new(rig.velocity.x, stackjumpPouwer, rig.velocity.z);

            Debug.Log(stackjumpPouwer.ToString());
        }


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
}
