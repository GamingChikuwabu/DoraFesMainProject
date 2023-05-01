using UnityEngine;

public class Swaying : MonoBehaviour
{
    // �I�𒆂ł��邩�ǂ���
    private bool isSelected = false;

    // �h���ʒu
    private float movePos;

    // �����ʒu
    private Vector3 initialPosition;

    void Start()
    {
        // y���W����
        movePos = transform.position.z;

        // �����ʒu����
        initialPosition = transform.position;   
    }

    void Update()
    {
        // StageSelect�X�v���N�g����擾�����
        StageSelect.STAGENAME stage = StageSelect.StageName;

        // stage�ϐ��ƃI�u�W�F�N�g�̖��O����v����ꍇtrue��
        if (gameObject.name == stage.ToString())
        {
            isSelected = true;
        }
        // ��v���Ȃ��ꍇ
        else
        {
            isSelected = false;
        }

        // �I������Ă���ꍇ
        if (isSelected)
        {
            //�㉺�ɗh�炷
            transform.position = new Vector3(transform.position.x, transform.position.y, movePos + Mathf.PingPong(Time.time / 3, 0.5f));

        }
        // �I������Ă��Ȃ��ꍇ
        else
        {
            // �����ʒu�ɖ߂�
            transform.position = initialPosition;

        }
    }
}