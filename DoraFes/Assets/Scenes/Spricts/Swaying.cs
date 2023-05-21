using UnityEngine;

public class Swaying : MonoBehaviour
{
    // �I�𒆂ł��邩�ǂ���
    private bool isSelected = false;

    // �����ʒu
    private Vector3 initialPosition;

    

    // �㉺�ړ��̑��x
    [Header("�ړ����x")]
    [SerializeField] private float speed = 1.0f;

    // �㉺�ړ��̕�
    [Header("����")]
    [SerializeField] private float amplitude = 0.5f;

    void Start()
    {
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
            // sin�֐����g���ď㉺�ɗh�炷
            float newPosition = Mathf.Sin(Time.time * speed) * amplitude + initialPosition.z;
            transform.position = new Vector3(initialPosition.x, initialPosition.y, newPosition);
        }
        // �I������Ă��Ȃ��ꍇ
        else
        {
            // �����ʒu�ɖ߂�
            transform.position = initialPosition;
        }
    }
}
