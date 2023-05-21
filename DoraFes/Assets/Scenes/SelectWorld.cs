using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageSelectInput;

public class SelectWorld : MonoBehaviour
{
    [SerializeField] Vector3[] ConstPos = new Vector3[5];

    private StageSelectInput stInput;

    int nowSelectWorld = 0;
    int nextSelectWorld = 0;

    void Start()
    {
        // �������W����
        transform.position = ConstPos[nowSelectWorld];
        // �R���|�[�l���g�擾
        stInput = gameObject.GetComponent<StageSelectInput>();
    }

    void Update()
    {
        // ���͏����X�V
        stInput.CheakInput();

        // ���͂���Ă���{�^���ɂ���ĕ���
        switch (stInput.isBottom)
        {
            // �������i���j�̏���
            case IsInputBottom.STICK_H_P:
                nowSelectWorld += 1;
                break;
            // �������i���j�̏���
            case IsInputBottom.STICK_H_N:
                nowSelectWorld -= 1;
                break;
        }

        // ���[���h�I���Œ[�����ɍs�����ꍇ
        if (nowSelectWorld < 0) nowSelectWorld = 4;
        else if (nowSelectWorld > 4) nowSelectWorld = 0;

        transform.position = ConstPos[nowSelectWorld];


        if (nowSelectWorld != nextSelectWorld)
        {

        }
       
    }
}
