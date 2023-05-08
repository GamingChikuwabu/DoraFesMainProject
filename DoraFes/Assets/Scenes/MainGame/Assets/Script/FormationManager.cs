using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    //���݂̃}���h���S���̐�
    private int _numMandoragara = 0;
    //����̈�ԍŏ��̃L������Landmark�̋���
    
    public float LandmarkToChar = -3;

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
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��̃}���h���S���𑝂₷
        NumMandragara++;
        //�ŏ��̃v���C���[�𑝂₷
        GameObject player =  GameObject.FindGameObjectWithTag("Player");
        if (player == null) 
        {
            Debug.Log("Player���ݒu����Ă��Ȃ���Tag��Player��Object������܂���");
        }
        PlayerMove pm =  player.GetComponent<PlayerMove>();
        //�����h�}�[�N��T��
        GameObject landmerk = GameObject.FindGameObjectWithTag("LandMark");
        if (landmerk == null)
        {
            Debug.Log("LandMark���ݒu����Ă��Ȃ���Tag��LandMark��Object������܂���");
        }

        LandMarkMove landMarkMove = landmerk.GetComponent<LandMarkMove>();
        
        pm.SetLandmark(landmerk, new Vector3(0.0f, 0.0f, -landMarkMove.LandMarkSpeed + LandmarkToChar));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
