using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MauseController : MonoBehaviour, IPointerEnterHandler
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // �{�^����I����Ԃɂ���
        EventSystem.current.SetSelectedGameObject(button.gameObject);
    }
}

