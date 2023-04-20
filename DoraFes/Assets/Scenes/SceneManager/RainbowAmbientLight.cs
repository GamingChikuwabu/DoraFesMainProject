using UnityEngine;
using UnityEngine.Rendering;

public class RainbowAmbientLight : MonoBehaviour
{
    public Color[] rainbowColors;  // 虹の色を表す配列

    private void Start()
    {
        // AmbientModeをTrilightに設定して、3つの環境光色を設定する
        RenderSettings.ambientMode = AmbientMode.Trilight;
        RenderSettings.ambientSkyColor = rainbowColors[0];
        RenderSettings.ambientEquatorColor = rainbowColors[1];
        RenderSettings.ambientGroundColor = rainbowColors[2];
    }

    private void Update()
    {
        // Time.timeを使用して時間の経過を取得
        float time = Time.time;

        // 配列のインデックスを計算するために、取得した時間の経過を配列の長さで割る
        int rainbowIndex = Mathf.FloorToInt(time / (1.0f * rainbowColors.Length));

        // 配列のインデックスを計算した後、配列から色を取得し、3つの環境光の色を設定
        RenderSettings.ambientSkyColor = rainbowColors[rainbowIndex % rainbowColors.Length];
        RenderSettings.ambientEquatorColor = rainbowColors[(rainbowIndex + 1) % rainbowColors.Length];
        RenderSettings.ambientGroundColor = rainbowColors[(rainbowIndex + 2) % rainbowColors.Length];
    }

    static void Light ()
    {

    }
}