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
    [Header("�O�ɐi�X�s�[�h")]
    [SerializeReference]
    private float _Forwardvelocity = 5.0f;
    [Header("�x�ꂽ���Ɍ��̈ʒu�ɖ߂��Ă���X�s�[�h")]
    [SerializeReference]
    private float BackMovePower = 20.0f;
    [Header("�R�C�����Ƃ������ɏオ��X�s�[�h")]
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

    //�^���d�͂��������邽�߂̕ϐ�
    private float stackGravity;

    //�n�ʂƐڐG���Ă��邩
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
            
            rig.AddForce(0.0f, JumpPower, 0.0f,ForceMode.Impulse);
            _Islanding = false;
            audioSource.PlayOneShot(sound1);
        }

        if(dethEvent.IsDamage == false)
        {
            //�O�ɐi����
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, _Forwardvelocity + coinMane.countCoin * CoinMagnification);

            //�x�ꂽ���̏���
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
