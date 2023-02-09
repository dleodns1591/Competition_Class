using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    public Vector2 touch = Vector2.zero;
    public RectTransform handle;
    public JoyStickValue value;

    float width;

    void Start()
    {
        rect = GetComponent<RectTransform>();

        // 중심을 기준으로 음수와 양수가 나뉘므로 크기의 절반만 필요하여 0.5를 곱해준다.
        width = rect.sizeDelta.x * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / width;

        if (touch.magnitude > 1)
            touch = touch.normalized;

        value.joyTouch = touch;
        handle.anchoredPosition = touch * width;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        value.joyTouch = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
