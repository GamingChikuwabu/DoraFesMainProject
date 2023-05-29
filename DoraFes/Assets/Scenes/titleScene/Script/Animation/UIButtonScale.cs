using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIButtonScale : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler, IDeselectHandler
{
    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private float duration = 0.1f;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ScaleUp();
    }

    public void OnSelect(BaseEventData eventData)
    {
        ScaleUp();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ScaleDown();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ScaleDown();
    }

    private void ScaleUp()
    {
        transform.SetAsLastSibling();
        transform.DOScale(initialScale * scaleFactor, duration);
    }

    private void ScaleDown()
    {
        transform.DOScale(initialScale, duration);
    }
}
