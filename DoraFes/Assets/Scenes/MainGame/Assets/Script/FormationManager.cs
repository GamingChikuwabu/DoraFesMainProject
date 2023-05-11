using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    //���݂̃}���h���S���̐�
    private int _numMandoragara = 0;
    //����̈�ԍŏ��̃L������Landmark�̋���

    public float LandmarkToChar = -3;

    MandNum mandNum;

    //�}���h���S���̐��̎擾�v���p�e�B
    public int NumMandragara
    {
        get
        {
            return _numMandoragara;
        }
        set
        {
            _numMandoragara = value;
            mandNum.ChangeNumber(_numMandoragara);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        mandNum = GameObject.Find("UI_MandNum").GetComponent<MandNum>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
