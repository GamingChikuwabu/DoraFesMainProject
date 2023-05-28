using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSound : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    //�t�B�[�o�[�����𔻒肷��ϐ�
    private bool isFever;
    private bool isSound;

    //�v���C���[��GlobalStatusManager�X�N���v�g��isFever���擾����ϐ�
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();

        //Player�̃X�N���v�g���擾����
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isFever = GSM.IsFever;

        if(isFever==false)
        {
            isSound = false;
        }

        if(isFever)
        {
            if (isSound == false)
            {
                audioSource.PlayOneShot(sound1);
                isSound = true;
            }
        }
        

    }
}
