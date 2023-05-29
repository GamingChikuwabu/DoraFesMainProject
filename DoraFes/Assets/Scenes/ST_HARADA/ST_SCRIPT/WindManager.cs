using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip seClip;

    [Header("風の吹く間隔")]
    [SerializeField] float interval = 5f;
    [Header("風が吹き終わるまでの時間")]
    [SerializeField] float interval02 = 1f;
    float intervalCount = 0f;   // 風が吹く間隔をカウント

    // *=*=*=*=*=*=*=*=*=*=*=*=*=*
    // パーティクル関連の変数宣言
    public ParticleSystem particleSystem;
    private ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule;
    [Header("火が揺らぐ方向")]
    [SerializeField] private float moveParticle = 18;

    // *=*=*=*=*=*=*=*=*=*=*=*=*=*
    // ライト関連の変数宣言
    [Header("対象のLight")]
    public Light light = null;
    private float higtIntensity = 0f;   // 変化前の元の明るさの値
    [Header("Lightの変化後の明るさ")]
    [SerializeField] private float lowIntensity = 200;
    [Header("遷移にかかる時間（進）")]
    [SerializeField] private float duration = 6f;
    [Header("遷移にかかる時間（戻）")]
    [SerializeField] private float duration2 = 3f;
    float changStartTime = 0f;   // 明るさの変化開始時刻を格納
    bool isChange = false;        // ライトの明るさが変化しているのか
    bool isHight = true;         // 変化前のライトの明るさが明るいかどうか

    [SerializeField] GameObject[] grass;

    void Start()
    {
        // ライト関連
        higtIntensity = light.intensity;    // ライトの変化前の値
        intervalCount = Time.time;          // 現在の時刻を取得

        // パーティクル関連
        forceOverLifetimeModule = particleSystem.forceOverLifetime;

        audioSource.clip = seClip;
    }

    void Update()
    {
        // 明るさが変化中かどうか
        if (isChange)
        {
            // 明るさを下げる処理
            if (isHight)
            {
                float startIntensity = higtIntensity;
                float endIntensity = lowIntensity;
                bool act = false;
                act = ChangeLight(changStartTime, duration, startIntensity, endIntensity);

                // 草をすべて揺らす
                for (int i = 0; i < grass.Length; i++)
                {
                    GrassMoveWithWind grassMove = grass[i].GetComponent<GrassMoveWithWind>();
                    grassMove.GrassMove(changStartTime, duration, grassMove.startAngel.x, grassMove.endAngle.x);
                }

                // 明るさの遷移が完了した
                if (act)
                {
                    isChange = false;
                    isHight = false;
                    intervalCount = Time.time;
                }
            }
            // 明るさを上げる処理
            else
            {
                float startIntensity = lowIntensity;
                float endIntensity = higtIntensity;
                bool act = false;
                act = ChangeLight(changStartTime, duration2, startIntensity, endIntensity);

                // 草をすべて揺らす
                for (int i = 0; i < grass.Length; i++)
                {
                    GrassMoveWithWind grassMove = grass[i].GetComponent<GrassMoveWithWind>();
                    grassMove.GrassMove(changStartTime, duration2, grassMove.endAngle.x, grassMove.startAngel.x);
                }

                // 明るさの遷移が完了した
                if (act)
                {
                    isChange = false;
                    isHight = true;
                    intervalCount = Time.time;
                    forceOverLifetimeModule.x = 1;
                }
            }
        }
        else
        {
            if (isHight)
            {
                if (Time.time - intervalCount >= interval)
                {
                    changStartTime = Time.time;
                    isChange = true;
                    forceOverLifetimeModule.x = moveParticle;

                    audioSource.PlayOneShot(seClip);
                }
            }
            else
            {
                if (Time.time - intervalCount >= interval02)
                {
                    changStartTime = Time.time;
                    isChange = true;
                    forceOverLifetimeModule.x = 1f;
                }
            }
        }
    }





    // ライトのパワーを下げる関数
    private bool ChangeLight(float startTime, float duration, float startPow, float endPow)
    {
        // 現在の経過時間
        float elapsedTime = Time.time - startTime;

        // 経過時間を遷移時間で割り、0から1までの割合に変換
        float t = Mathf.Clamp01(elapsedTime / duration);

        // 変化前の値と変化後の値をtの割合で線形補間しライトの強さに代入
        light.intensity = Mathf.Lerp(startPow, endPow, t);

        // 規定時間が経過した？
        if (t == 1) return true;
        return false;
    }
}
