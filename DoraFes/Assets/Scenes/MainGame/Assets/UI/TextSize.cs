using System.Diagnostics;
using UnityEngine;
using TMPro;

public class TextSize : MonoBehaviour
{
    public TMP_Text textComponent; // �T�C�Y�𒲐�����e�L�X�g�R���|�[�l���g
    public float baseFontSize = 20f; // �����̃t�H���g�T�C�Y
    public
    float sizePerDigit = 2f; // �������Ƃ̃T�C�Y�̕ω���

    private void Start()
    {
     
    }

    private void Update()
    {
        // �e�L�X�g�̌����Ɋ�Â��ăt�H���g�T�C�Y���v�Z����
        int digitCount = textComponent.text.Length;
        float fontSize = baseFontSize - (digitCount * sizePerDigit);

        // �t�H���g�T�C�Y��ݒ肷��
        textComponent.fontSize = Mathf.Max(fontSize, 1f); // �ŏ��T�C�Y��1�ɂ���i�[���ɂȂ�Ȃ��悤�ɂ���j
    }
}