using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMove : MonoBehaviour
{
    [Header("横移動の力")]
    [SerializeReference]
    private float PlayerHorizontalPower;
    [Header("横の減衰率")]
    [SerializeReference]
    private float HorizontalAttenuation = 0.9f;
    [Header("ジャンプ力")]
    public float JumpPower = 5.0f;
    [Header("疑似重力")]
    [SerializeReference]
    private float Gravity = 3.0f;
    [Header("前に進スピード")]
    public float Forwardvelocity = 5.0f;
    [Header("遅れた時に元の位置に戻ってくるスピード")]
    [SerializeReference]
    private float BackMovePower = 20.0f;

    private Vector3 _NewPlayerPosition;

    public Vector3 NewPlayerPos
    {
        get { return _NewPlayerPosition; }
    }

    //疑似重力を実装するための変数
    private float stackGravity;

    //地面と接触しているか
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
        //横移動の処理
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

        //ジャンプの処理
        if(Input.GetButtonDown("Jump") && _Islanding == true)
        {
            stackGravity = JumpPower;
            _Islanding = false;
        }

        //重力の処理
        if (_Islanding == false)
        {
            stackGravity -= Time.deltaTime * Gravity;
        }

        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y + stackGravity, rig.velocity.z);

        Debug.Log(_Islanding.ToString());


        //前に進処理
        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, Forwardvelocity);

        //遅れた時の処理
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
