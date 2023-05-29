using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComic : MonoBehaviour
{
    private Vector3 targetPosion;

    [SerializeField] private GameObject nextComic;

    private float speed = 2000.0f;

    [Header("frameは外す")]
    [SerializeField] private bool needMove = true;

    //ボタンフラグ
    private bool isPush;

    //サウンド
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isPush = false;
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //移動座標を入れる
        targetPosion = new Vector3(transform.position.x, transform.position.y, 959);

        if (needMove)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPush==false)
        {
            if (Input.GetButtonDown("Comic"))
            {
                audioSource.PlayOneShot(sound1);
                Active();
                isPush = true;
            }
        }
       
    }

    private void FixedUpdate()
    {
        if (needMove)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosion, step);
        }

    }

    private void Active()
    {
        nextComic.SetActive(true);
    }

    
}
