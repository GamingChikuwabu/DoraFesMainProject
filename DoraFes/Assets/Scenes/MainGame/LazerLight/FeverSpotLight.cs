using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpotLight : MonoBehaviour
{

    private bool isFever;

    //�v���C���[��GlobalStatusManager�X�N���v�g��isFever���擾����ϐ�
    private GameObject PlayerObject;
    private GlobalStatusManager GSM;

    // Start is called before the first frame update
    void Start()
    {
        isFever = false;

        //Player�̃X�N���v�g���擾����
        PlayerObject = GameObject.Find("Player");
        GSM = PlayerObject.GetComponent<GlobalStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isFever = GSM.IsFever;

        if (isFever)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
