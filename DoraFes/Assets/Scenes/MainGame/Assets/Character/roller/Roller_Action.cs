using UnityEngine;

public class Roller_Action : MonoBehaviour
{
    public float speed = 5f;         // �ړ����x
    public float amplitude = 2f;     // �֍s�̐U��
    public float frequency = 1f;     // �֍s�̎��g��

    private float startTime;         // �J�n����

    private void Start()
    {
        // �J�n���Ԃ��L�^
        startTime = Time.time;
    }

    private void Update()
    {
        // ���݂̌o�ߎ��Ԃ��擾
        float elapsedTime = Time.time - startTime;

        // X���W���O�p�֐��Ōv�Z
        float xPos = Mathf.Sin(elapsedTime * frequency) * amplitude;

        // �I�u�W�F�N�g���֍s���Ȃ���O�i������
        transform.Translate(new Vector3(xPos, 0f, speed) * Time.deltaTime);
    }
}