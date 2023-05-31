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
    [Header("前に進スピード")]
    [SerializeReference]
    private float _Forwardvelocity = 5.0f;
    [Header("遅れた時に元の位置に戻ってくるスピード")]
    [SerializeReference]
    private float BackMovePower = 20.0f;
    [Header("コインをとった時に上がるスピード")]
    [SerializeReference]
    private float CoinMagnification = 0.1f;

    private Vector3 _NewPlayerPosition;

            public AudioClip sound1;
            public AudioSource audioSource;


    public Vector3 NewPlayerPos
    {
        get { return _NewPlayerPosition; }
    }

    public float Fowardvelocity
    {
        get { return _Forwardvelocity + coinMane.countCoin * CoinMagnification; }
    }

    //疑似重力を実装するための変数
    private float stackGravity;

    //地面と接触しているか
    private bool _Islanding = true;

    public bool Islanding => _Islanding;

    private Rigidbody rig;

    private CoinManager coinMane;

    private DethEvent dethEvent;

    private void Awake()
    {
        _NewPlayerPosition = transform.position;
        Physics.gravity = new Vector3(0.0f,-9.8f * 2.5f,0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        coinMane = GetComponent<CoinManager>();
        dethEvent = GetComponent<DethEvent>();
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
            
            rig.AddForce(0.0f, JumpPower, 0.0f,ForceMode.Impulse);
            _Islanding = false;
            audioSource.PlayOneShot(sound1);
        }

        if(dethEvent.IsDamage == false)
        {
            //前に進処理
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, _Forwardvelocity + coinMane.countCoin * CoinMagnification);

            //遅れた時の処理
            Vector3 tempvec = new Vector3(0.0f, 0.0f, coinMane.transform.position.z) - new Vector3(0.0f, 0.0f, transform.position.z);
            rig.AddForce(tempvec * BackMovePower);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Untagged")
        {
            _NewPlayerPosition = transform.position;
            _Islanding = true;
            Debug.Log("in");
        }
    }
}
