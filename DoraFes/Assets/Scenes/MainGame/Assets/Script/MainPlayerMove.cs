using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMove : MonoBehaviour
{
    [Header("���ړ��̗�")]
    [SerializeReference]
    private float PlayerHorizontalPower;
    [Header("���̌�����")]
    [SerializeReference]
    private float HorizontalAttenuation = 0.9f;
    [Header("�W�����v��")]
    public float JumpPower = 5.0f;
    [Header("�^���d��")]
    [SerializeReference]
    private float Gravity = 3.0f;
    [Header("�O�ɐi�X�s�[�h")]
    public float Forwardvelocity = 5.0f;
    [Header("�x�ꂽ���Ɍ��̈ʒu�ɖ߂��Ă���X�s�[�h")]
    [SerializeReference]
    private float BackMovePower = 20.0f;

    private Vector3 _NewPlayerPosition;

    public Vector3 NewPlayerPos
    {
        get { return _NewPlayerPosition; }
    }

    //�^���d�͂��������邽�߂̕ϐ�
    private float stackGravity;

    //�n�ʂƐڐG���Ă��邩
    private bool _Islanding = true;

    public bool Islanding => _Islanding;

    private Rigidbody rig;

    private GameObject obj;

    private void Awake()
    {
        _NewPlayerPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        obj = GameObject.Find("LandMarkSphere");
    }

    // Update is called once per frame
    void Update()
    {
        //���ړ��̏���
        if(Input.GetAxis("Horizontal") < 0)
        {
            rig.velocity = new Vector3(-PlayerHorizontalPower, rig.velocity.y, rig.velocity.z);
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            rig.velocity = new Vector3(PlayerHorizontalPower, rig.velocity.y, rig.velocity.z);
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x * HorizontalAttenuation, rig.velocity.y, rig.velocity.z);
        }

        //�W�����v�̏���
        if(Input.GetButtonDown("Jump") && _Islanding == true)
        {
            stackGravity = JumpPower;
            _Islanding = false;
        }

        //�d�͂̏���
        if (_Islanding == false)
        {
            stackGravity -= Time.deltaTime * Gravity;
        }

        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y + stackGravity, rig.velocity.z);

        Debug.Log(_Islanding.ToString());


        //�O�ɐi����
        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, Forwardvelocity);

        //�x�ꂽ���̏���
        Vector3 tempvec = new Vector3(0.0f,0.0f,obj.transform.position.z) - new Vector3(0.0f, 0.0f, transform.position.z);
        rig.AddForce(tempvec * BackMovePower);


    }

    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, new Vector3(0.0f, -1.0f, 0.0f), 1.0f))
        {
            if (rig.velocity.y <= 0)
            {
                _Islanding = true;
                _NewPlayerPosition = transform.position;
                Debug.Log("in");
            }
        }
    }
}
