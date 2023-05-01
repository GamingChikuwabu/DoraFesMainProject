//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShowHide : MonoBehaviour
//{
//    // �I�𒆂ł��邩�ǂ���
//    private bool isSelected = false;

//    [SerializeField] private GameObject ArrowToMap2;
//    [SerializeField] private GameObject ArrowToMap3;
//    [SerializeField] private GameObject ArrowToMap4;
//    [SerializeField] private GameObject ArrowToMap5;
//    [SerializeField] private GameObject ArrowBackToMap1;
//    [SerializeField] private GameObject ArrowBackToMap2;
//    [SerializeField] private GameObject ArrowBackToMap3;
//    [SerializeField] private GameObject ArrowBackToMap4;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // ���߂͔�\���ɂ���
//        ArrowToMap2.SetActive(false);
//        ArrowToMap3.SetActive(false);
//        ArrowToMap4.SetActive(false);
//        ArrowToMap5.SetActive(false);
//        ArrowBackToMap1.SetActive(false);
//        ArrowBackToMap2.SetActive(false);
//        ArrowBackToMap3.SetActive(false);
//        ArrowBackToMap4.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // StageSelect�X�v���N�g����擾�����
//        StageSelect.STAGENAME stage = StageSelect.StageName;

//          switch(stage)
//            {
//                case StageSelect.STAGENAME.TOMAP2:

//                ArrowToMap2.SetActive(true);

//                    break;

//                case StageSelect.STAGENAME.BACKTOMAP1:

//                ArrowBackToMap1.SetActive(true);

//                break;

//                case StageSelect.STAGENAME.TOMAP3:

//                ArrowToMap3.SetActive(true);

//                break;

//                case StageSelect.STAGENAME.BACKTOMAP2:

//                ArrowBackToMap2.SetActive(true);

//                break;

//                case StageSelect.STAGENAME.TOMAP4:

//                ArrowToMap4.SetActive(true);

//                break;

//                case StageSelect.STAGENAME.BACKTOMAP3:

//                ArrowBackToMap3.SetActive(true);

//                break;

//                case StageSelect.STAGENAME.TOMAP5:

//                ArrowToMap5.SetActive(true);

//                break;

//                case StageSelect.STAGENAME.BACKTOMAP4:

//                ArrowBackToMap4.SetActive(true);

//                break;
//            }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    // �I�𒆂ł��邩�ǂ���
    private bool isSelected = false;

    [SerializeField] private GameObject ArrowToMap2;
    [SerializeField] private GameObject ArrowToMap3;
    [SerializeField] private GameObject ArrowToMap4;
    [SerializeField] private GameObject ArrowToMap5;
    [SerializeField] private GameObject ArrowBackToMap1;
    [SerializeField] private GameObject ArrowBackToMap2;
    [SerializeField] private GameObject ArrowBackToMap3;
    [SerializeField] private GameObject ArrowBackToMap4;

    // Start is called before the first frame update
    void Start()
    {
        // ���߂͔�\���ɂ���
        HideAllArrows();
    }

    // Update is called once per frame
    void Update()
    {
        // StageSelect�X�v���N�g����擾�����
        StageSelect.STAGENAME stage = StageSelect.StageName;

        // �S�Ă�Arrow���\���ɂ�����
        HideAllArrows();

        switch (stage)
        {
            case StageSelect.STAGENAME.TOMAP2:
                ArrowToMap2.SetActive(true);
                break;

            case StageSelect.STAGENAME.BACKTOMAP1:
                ArrowBackToMap1.SetActive(true);
                break;

            case StageSelect.STAGENAME.TOMAP3:
                ArrowToMap3.SetActive(true);
                break;

            case StageSelect.STAGENAME.BACKTOMAP2:
                ArrowBackToMap2.SetActive(true);
                break;

            case StageSelect.STAGENAME.TOMAP4:
                ArrowToMap4.SetActive(true);
                break;

            case StageSelect.STAGENAME.BACKTOMAP3:
                ArrowBackToMap3.SetActive(true);
                break;

            case StageSelect.STAGENAME.TOMAP5:
                ArrowToMap5.SetActive(true);
                break;

            case StageSelect.STAGENAME.BACKTOMAP4:
                ArrowBackToMap4.SetActive(true);
                break;
        }
    }

    // �S�Ă�Arrow���\���ɂ�����
    private void HideAllArrows()
    {
        ArrowToMap2.SetActive(false);
        ArrowToMap3.SetActive(false);
        ArrowToMap4.SetActive(false);
        ArrowToMap5.SetActive(false);
        ArrowBackToMap1.SetActive(false);
        ArrowBackToMap2.SetActive(false);
        ArrowBackToMap3.SetActive(false);
        ArrowBackToMap4.SetActive(false);
    }
}