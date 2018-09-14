using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ControlButton controlButtonScript;
    public JoystickState buttonState;

    private RectTransform rectTransform;
    private PointerEventData eventData;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
            if (controlButtonScript.isDragControlButton)
                JoystickPositionLock();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        controlButtonScript.OnDrag(eventData);
        JoystickPositionLock();
    }

    private void JoystickPositionLock()
    {
        controlButtonScript.rectTrans.anchoredPosition = rectTransform.anchoredPosition;
        controlButtonScript.joystickState = buttonState;

        controlButtonScript.AddCommand(buttonState);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        controlButtonScript.OnPointerUp(eventData);
    }
}
