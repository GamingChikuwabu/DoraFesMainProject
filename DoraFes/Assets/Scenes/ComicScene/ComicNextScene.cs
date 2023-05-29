using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicNextScene : MonoBehaviour
{
    private bool isMove;

    private Vector3 targetPosion;

    [Header("�X�s�[�h")]
    [SerializeField] private float speed = 1500.0f;

    // ���[�h�V�[���p�̃I�u�W�F�N�g������Ă���
    private GameObject LoadSceneObject;
    private LoadScene LS;

    [Header("���ɑJ�ڂ���V�[��")]
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        targetPosion = new Vector3(transform.position.x, transform.position.y, 959);

        gameObject.SetActive(false);

        isMove = false;

        //LoadScene�X�N���v�g�̕ϐ�������Ă���
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
                //���[�h��ʌ�ɑJ�ڂ�����V�[�������Z�b�g
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
