using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicNextScene : MonoBehaviour
{
    private bool isMove;

    private Vector3 targetPosion;

    [Header("スピード")]
    [SerializeField] private float speed = 1500.0f;

    // ロードシーン用のオブジェクトを取ってくる
    private GameObject LoadSceneObject;
    private LoadScene LS;

    [Header("次に遷移するシーン")]
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        targetPosion = new Vector3(transform.position.x, transform.position.y, 959);

        gameObject.SetActive(false);

        isMove = false;

        //LoadSceneスクリプトの変数を取ってくる
        LoadSceneObject = GameObject.Find("LoadScene");
        LS = LoadSceneObject.GetComponent<LoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (Input.GetButtonDown("Comic"))
            {
                //ロード画面後に遷移させるシーン名をセット
                LS.SetLoadName(nextScene);
            }
        }
    }

    private void FixedUpdate()
    {
        
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosion, step);

        if (transform.position == targetPosion)
        {
            isMove = true;
        }

    }
}
