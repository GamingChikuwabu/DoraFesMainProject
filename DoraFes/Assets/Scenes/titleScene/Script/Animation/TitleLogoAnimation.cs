using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleLogoAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 2.0f;
    [SerializeField] private float startYPosition = 10.0f;
    [SerializeField] private float endYPosition = 0.0f;
    [SerializeField] private Image whiteScreen; // フェードインに使用する白画面
    [SerializeField] private ParticleSystem confetti;  // クラッカーのエフェクト
    

    private bool hasPlayedBGM = false; // 新たに追加したフラグ

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, startYPosition, transform.position.z);
        whiteScreen.color = new Color(1f, 1f, 1f, 0f); // 白画面を透明にして非表示にする
    }

    public void AnimateTitleLogo()
    {
        transform.DOMoveY(endYPosition, animationDuration).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            // ロゴが着地したら一瞬白画面をフェードイン
            DOTween.Sequence()
                .Append(whiteScreen.DOColor(new Color(1f, 1f, 1f, 1f), 0.1f)) // 0.1秒でフェードイン
                .Append(whiteScreen.DOColor(new Color(1f, 1f, 1f, 0f), 0.1f)) // 0.1秒でフェードアウト
                .SetUpdate(true);

            // クラッカーエフェクトの再生
            confetti.Play();

            // BGMの再生
              if (!hasPlayedBGM) // 新たに追加したチェック
            {
                TitleLogoManager.Instance.PlayBGM();
                hasPlayedBGM = true;
            }
        });
    }
}
