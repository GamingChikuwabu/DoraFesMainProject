using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �R�C�����v���C���[�ɋz�����܂��X�N���v�g
public class CoinAbsorption : MonoBehaviour
{

    //�J�����̃X�s�[�h���擾����I�u�W�F�N�g
    private GameObject landmark;

    // �ړ���̑Ώ�
    private GameObject Player;
    private GlobalStatusManager GSM;

    //�z�����݃X�s�[�h
    private float speed = 80.0f;

    //�z�����ݔ͈�
    private float range = 40.0f;

    [Header("�J�����̃X�s�[�h�ɉ��Z����l")]
    [SerializeField] private float addspeed = 10.0f;

    // �R�C���ƃv���C���[�̋������i�[����ϐ�
    private float distance;

    private Vector3 targetPosition;

    private void Start()
    {
        //�ڕW�I�u�W�F�N�g�̎擾
        Player = GameObject.FindGameObjectWithTag("MainPlayer");
        GSM = Player.GetComponent<GlobalStatusManager>();
    }

    void Update()
    {
        if (GSM.IsFever)
        {
            // �R�C���ƃv���C���[�̋���
            distance = Player.transform.position.z - transform.position.z;

            // ��Βl�����
            distance = Mathf.Abs(distance);

            // �R�C���ƃv���C���[�̋������z�����ݔ͈͂��Z��������
            if (distance < range)
            {
                //speed = Mathf.Max(speed, LM.LandMarkSpeed + addspeed);

                // �R�C���̈ړ�����v���C���[�̈ʒu�ɐݒ肷��
                targetPosition = Player.transform.position;

                // �z�����܂��X�s�[�h
                float step = speed * Time.deltaTime;

                // Vector3.MoveTowards (��ƂȂ�J�n���W, ���B���������W, �ړ����x)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            }
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //}

}
