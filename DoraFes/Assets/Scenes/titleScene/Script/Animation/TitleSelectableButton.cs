using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TitleSelectableButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private float selectedScale = 1.2f; // 選択時のスケール
    [SerializeField] private float animationDuration = 0.2f; // アニメーション時間

    private Vector3 _originalScale; // 元のスケールを保存するための変数

    private void Awake()
    {
        _originalScale = transform.localScale; // 元のスケールを保存
    }

    // ボタンが選択されたときに呼ばれるメソッド
    public void OnSelect(BaseEventData eventData)
    {
        transform.DOScale(selectedScale, animationDuration); // スケールを拡大
    }

    // ボタンが選択解除されたときに呼ばれるメソッド
    public void OnDeselect(BaseEventData eventData)
    {
        transform.DOScale(_originalScale, animationDuration); // スケールを元に戻す
    }
}
