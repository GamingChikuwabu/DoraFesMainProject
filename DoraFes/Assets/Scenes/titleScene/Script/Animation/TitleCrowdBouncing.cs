using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleCrowdBouncing : MonoBehaviour
{
    [Header("Bounce Animation")]

    [Header("バウンスの高さ")]
    [SerializeField] private float bounceHeight = 10f;

    [Header("バウンスの時間")]
    [SerializeField] private float bounceDuration = 1f;

    [Header("バウンスのイージング")]
    [SerializeField] private Ease bounceEaseType = Ease.InOutSine;

    private RectTransform _rectTransform;
    private Vector2 _startPosition;

 
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.anchoredPosition;
        BounceAnimation();
    }

    private void BounceAnimation()
    {
        _rectTransform.DOAnchorPosY(_startPosition.y + bounceHeight, bounceDuration)
                      .SetEase(bounceEaseType)
                      .SetLoops(-1, LoopType.Yoyo);
    }
}
