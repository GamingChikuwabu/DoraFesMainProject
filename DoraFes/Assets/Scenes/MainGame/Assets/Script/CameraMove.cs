using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMove : MonoBehaviour
{
    [Header("�J������LandMark�Ƃ̋���Z")]
    public float Zoffset = 10.0f;
    [Header("�J������LandMark�Ƃ̋���Y")]
    public float Yoffset = 5.0f;
    [Header("Z�����ւ̒Ǐ]�t���O")]
    public bool Xfollow = true;

    private Transform m_transform;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GameObject.FindGameObjectWithTag("LandMark").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Xfollow)
        {
            transform.position = new(m_transform.position.x, m_transform.position.y + Yoffset, m_transform.position.z - Zoffset);
        }
        else
        {
            transform.position = new(transform.position.x, m_transform.position.y + Yoffset, m_transform.position.z - Zoffset);
        }
        

    }


}
