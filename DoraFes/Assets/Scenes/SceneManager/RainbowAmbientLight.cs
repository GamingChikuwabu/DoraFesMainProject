using UnityEngine;
using UnityEngine.Rendering;

public class RainbowAmbientLight : MonoBehaviour
{
    public Color[] rainbowColors;  // ���̐F��\���z��

    private void Start()
    {
        // AmbientMode��Trilight�ɐݒ肵�āA3�̊����F��ݒ肷��
        RenderSettings.ambientMode = AmbientMode.Trilight;
        RenderSettings.ambientSkyColor = rainbowColors[0];
        RenderSettings.ambientEquatorColor = rainbowColors[1];
        RenderSettings.ambientGroundColor = rainbowColors[2];
    }

    private void Update()
    {
        // Time.time���g�p���Ď��Ԃ̌o�߂��擾
        float time = Time.time;

        // �z��̃C���f�b�N�X���v�Z���邽�߂ɁA�擾�������Ԃ̌o�߂�z��̒����Ŋ���
        int rainbowIndex = Mathf.FloorToInt(time / (1.0f * rainbowColors.Length));

        // �z��̃C���f�b�N�X���v�Z������A�z�񂩂�F���擾���A3�̊����̐F��ݒ�
        RenderSettings.ambientSkyColor = rainbowColors[rainbowIndex % rainbowColors.Length];
        RenderSettings.ambientEquatorColor = rainbowColors[(rainbowIndex + 1) % rainbowColors.Length];
        RenderSettings.ambientGroundColor = rainbowColors[(rainbowIndex + 2) % rainbowColors.Length];
    }

    static void Light ()
    {

    }
}