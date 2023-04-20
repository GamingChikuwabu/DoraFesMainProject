using UnityEngine;
using UnityEngine.Rendering;

public class SmoothRainbowAmbientLight : MonoBehaviour
{
    public Color[] rainbowColors;  // ���̐F��\���z��
    public float colorChangeDuration = 5f;  // �F���ς��܂ł̎���

    private Color currentSkyColor;
    private Color currentEquatorColor;
    private Color currentGroundColor;

    private Color nextSkyColor;
    private Color nextEquatorColor;
    private Color nextGroundColor;

    private float colorChangeStartTime;

    private void Start()
    {
        // AmbientMode��Trilight�ɐݒ肵�āA3�̊����F��ݒ肷��
        RenderSettings.ambientMode = AmbientMode.Trilight;
        currentSkyColor = rainbowColors[0];
        currentEquatorColor = rainbowColors[1];
        currentGroundColor = rainbowColors[2];

        // ���̐F��ݒ�
        SetNextColors();
    }

    private void Update()
    {
        // ���Ԃ̌o�߂ɂ��A���݂̐F�Ǝ��̐F�̊Ԃ�⊮����
        float t = (Time.time - colorChangeStartTime) / colorChangeDuration;
        RenderSettings.ambientSkyColor = Color.Lerp(currentSkyColor, nextSkyColor, t);
        RenderSettings.ambientEquatorColor = Color.Lerp(currentEquatorColor, nextEquatorColor, t);
        RenderSettings.ambientGroundColor = Color.Lerp(currentGroundColor, nextGroundColor, t);

        // ���̐F�ɐ؂�ւ���
        if (t >= 1f)
        {
            currentSkyColor = nextSkyColor;
            currentEquatorColor = nextEquatorColor;
            currentGroundColor = nextGroundColor;
            SetNextColors();
        }
    }

    // ���̐F��ݒ肷��
    private void SetNextColors()
    {
        int nextSkyIndex = (GetColorIndex(currentSkyColor) + 1) % rainbowColors.Length;
        int nextEquatorIndex = (GetColorIndex(currentEquatorColor) + 1) % rainbowColors.Length;
        int nextGroundIndex = (GetColorIndex(currentGroundColor) + 1) % rainbowColors.Length;

        nextSkyColor = rainbowColors[nextSkyIndex];
        nextEquatorColor = rainbowColors[nextEquatorIndex];
        nextGroundColor = rainbowColors[nextGroundIndex];

        colorChangeStartTime = Time.time;
    }

    // �z�񂩂�w�肵���F�̃C���f�b�N�X���擾����
    private int GetColorIndex(Color color)
    {
        for (int i = 0; i < rainbowColors.Length; i++)
        {
            if (rainbowColors[i] == color)
            {
                return i;
            }
        }

        return -1;
    }
}