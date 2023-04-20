using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //à⁄ìÆó 
    [Header("à⁄ìÆéûÇÃóÕ")]
    [SerializeField]
    private float MovingForce = 3;

    [Header("ãÛíÜÇ…Ç¢ÇÈÇ∆Ç´ÇÃà⁄ìÆêßå¿")]
    [SerializeField]
    private float MovingResistance = 0.5f;

    [Header("ÉWÉÉÉìÉvóÕ")]
    [SerializeField]
    private float JumpPawer = 10;

    [Header("èdóÕÇ…ó^Ç¶ÇÈóÕÇÃëÂÇ´Ç≥")]
    [SerializeField]
    private float GravityAffect = 2;

    public GameObject gCamera;
    CameraMove CM;

    //PlayerÇÃRigidbody
    private Rigidbody rig;
    public bool JumpFlg;

    // Start is called before the first frame update
    void Start()
    {
        JumpFlg = true;
        rig = GetComponent<Rigidbody>();
        CM = gCamera.GetComponent<CameraMove>();
        if(CM == null)
        {
            Debug.Log("Ç©ÇﬂÇÁÇ»Çµ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(JumpFlg)
            {
                rig.velocity = new Vector3(MovingForce, rig.velocity.y, 0.0f);
            }
            else
            {
                rig.velocity = new Vector3(0.0f, rig.velocity.y, MovingForce * MovingResistance);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (JumpFlg)
            {
                rig.velocity = new Vector3(-MovingForce, rig.velocity.y, 0.0f);
            }
            else
            {
                rig.velocity = new Vector3(0.0f, rig.velocity.y, -(MovingForce * MovingResistance));
            }
        }

        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + Time.deltaTime * CM.speed);

        rig.AddForce(Vector3.down * GravityAffect);

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(JumpFlg)
            {
                rig.AddForce(new Vector3(0.0f, JumpPawer, 0.0f), ForceMode.Impulse);
                JumpFlg = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        JumpFlg = true;
    }
}
