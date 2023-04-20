using UnityEngine;
using UnityEngine.Rendering;

public class SmoothRainbowAmbientLight : MonoBehaviour
{
    public Color[] rainbowColors;  // 虹の色を表す配列
    public float colorChangeDuration = 5f;  // 色が変わるまでの時間

    private Color currentSkyColor;
    private Color currentEquatorColor;
    private Color currentGroundColor;

    private Color nextSkyColor;
    private Color nextEquatorColor;
    private Color nextGroundColor;

    private float colorChangeStartTime;

    private void Start()
    {
        // AmbientModeをTrilightに設定して、3つの環境光色を設定する
        RenderSettings.ambientMode = AmbientMode.Trilight;
        currentSkyColor = rainbowColors[0];
        currentEquatorColor = rainbowColors[1];
        currentGroundColor = rainbowColors[2];

        // 次の色を設定
        SetNextColors();
    }

    private void Update()
    {
        // 時間の経過により、現在の色と次の色の間を補完する
        float t = (Time.time - colorChangeStartTime) / colorChangeDuration;
        RenderSettings.ambientSkyColor = Color.Lerp(currentSkyColor, nextSkyColor, t);
        RenderSettings.ambientEquatorColor = Color.Lerp(currentEquatorColor, nextEquatorColor, t);
        RenderSettings.ambientGroundColor = Color.Lerp(currentGroundColor, nextGroundColor, t);

        // 次の色に切り替える
        if (t >= 1f)
        {
            currentSkyColor = nextSkyColor;
            currentEquatorColor = nextEquatorColor;
            currentGroundColor = nextGroundColor;
            SetNextColors();
        }
    }

    // 次の色を設定する
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

    // 配列から指定した色のインデックスを取得する
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