using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkMove : MonoBehaviour
{ 
    private GameObject ChildCamera;
    public float LandMarkSpeed = 5;
    public float PlayerMovePower = 3;
    private float RetuerPlayerMovePower = 0;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトのカメラを検索
        ChildCamera = transform.GetChild(0).gameObject;
        if(!ChildCamera)
        {
            Debug.Log("Child camera can not find");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z  + LandMarkSpeed);

        if(Input.GetKey(KeyCode.A))
        {
            RetuerPlayerMovePower = -PlayerMovePower;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RetuerPlayerMovePower = PlayerMovePower;
        }
        else
        {
            RetuerPlayerMovePower = 0;
        }
    }

    public float GetMovePower()
    {
        return RetuerPlayerMovePower;
    }
}
