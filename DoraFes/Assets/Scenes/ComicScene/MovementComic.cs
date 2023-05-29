using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComic : MonoBehaviour
{
    private Vector3 targetPosion;

    [SerializeField] private GameObject nextComic;

    [Header("スピード")]
    [SerializeField] private float speed = 1500.0f;

    [Header("frameは外す")]
    [SerializeField] private bool needMove = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPosion = new Vector3(transform.position.x, transform.position.y, 959);

        if (needMove)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(needMove == false)
        //{
        //    if (Input.GetButtonDown("Comic"))
        //    {
        //        Active();
        //    }
        //}

        if (Input.GetButtonDown("Comic"))
        {
            Active();
        }
    }

    private void FixedUpdate()
    {
        if (needMove)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosion, step);

            if (transform.position == targetPosion)
            {
                needMove = false;
            }
        }

    }

    private void Active()
    {
        nextComic.SetActive(true);
    }

    //private void ComicMove()
    //{
    //    float step = speed * Time.deltaTime;

    //    transform.position = Vector3.MoveTowards(transform.position, targetPosion, step);
    //}
}
