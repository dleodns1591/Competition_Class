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

        // �߽��� �������� ������ ����� �����Ƿ� ũ���� ���ݸ� �ʿ��Ͽ� 0.5�� �����ش�.
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
