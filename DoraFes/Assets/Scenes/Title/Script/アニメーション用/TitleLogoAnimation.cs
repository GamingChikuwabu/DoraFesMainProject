using UnityEngine;
using DG.Tweening;

public class TitleLogoAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 2.0f;
    [SerializeField] private float startYPosition = 10.0f;
    [SerializeField] private float endYPosition = 0.0f;

    private void Start()
    {
        AnimateTitleLogo();
    }

    private void AnimateTitleLogo()
    {
        transform.position = new Vector3(transform.position.x, startYPosition, transform.position.z);
        transform.DOMoveY(endYPosition, animationDuration).SetEase(Ease.OutBounce);
    }
}
