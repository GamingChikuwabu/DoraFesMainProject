using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpotlightController : MonoBehaviour
{
    [SerializeField] private List<Transform> characterTransforms; // キャラクターの位置リスト
    [SerializeField] private float spotlightTime = 1f; // スポットライトが各キャラクターに当たる時間
    [SerializeField] private float finalLightIntensity = 2f; // 最後のキャラクターに当たったときの光の強度
    [SerializeField] private float transitionTime = 1f; // 光の強度が変化する時間

    private Light spotlight; // スポットライト

    private void Start()
    {
        spotlight = GetComponent<Light>();

        // スポットライトのシーケンスを作成
        Sequence spotlightSequence = DOTween.Sequence();

        // 各キャラクターに順番にスポットライトを当てる
        foreach (Transform character in characterTransforms)
        {
            spotlightSequence.Append(transform.DOMove(character.position, spotlightTime))
                             .AppendInterval(spotlightTime);
        }

        // 最後のキャラクターに当たった後に光の強度を上げる
        spotlightSequence.Append(DOTween.To(() => spotlight.intensity, x => spotlight.intensity = x, finalLightIntensity, transitionTime));

        // シーケンスを開始
        spotlightSequence.Play();
    }
}
