using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizonScroll : MonoBehaviour
{
    //スクロールスピード
    [Header("スクロールスピード")]
    [SerializeField]private float ScrollSpeed = 1.0f;

    //範囲外にいったときに移動する座標
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = gameObject.transform.position;
        newPosition.x = -2081;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //スクロールさせる
        transform.Translate(-ScrollSpeed + Time.deltaTime, 0.0f, 0.0f);

        if(transform.position.x>=2118)
        {
            gameObject.transform.position = newPosition;
        }
    }
}
