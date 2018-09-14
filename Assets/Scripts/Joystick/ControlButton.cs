using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlButton : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Player player;
    public JoystickState joystickState = JoystickState.NONE;

    public RectTransform rectTrans;
    public RectTransform downButton;

    public bool isDragControlButton = false;

    private JoystickState joystickPreviousState = JoystickState.NONE;
    private RectTransform parentPanel;
    private Vector2 pos = Vector2.zero;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        parentPanel = transform.parent.GetComponent<RectTransform>();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        isDragControlButton = true;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(parentPanel, eventData.position, eventData.pressEventCamera, out pos))
        {
            if (Mathf.Abs(pos.x) <= parentPanel.sizeDelta.x / 2 - rectTrans.sizeDelta.x / 2 && Mathf.Abs(pos.y) <= parentPanel.sizeDelta.y / 2 - rectTrans.sizeDelta.y / 2)
                JoystickPositionLimit(false, false);
            else if (Mathf.Abs(pos.x) > parentPanel.sizeDelta.x / 2 - rectTrans.sizeDelta.x / 2 && Mathf.Abs(pos.y) > parentPanel.sizeDelta.y / 2 - rectTrans.sizeDelta.y / 2)
                JoystickPositionLimit(true, true);
            else if (Mathf.Abs(pos.x) > parentPanel.sizeDelta.x / 2 - rectTrans.sizeDelta.x / 2)
                JoystickPositionLimit(true, false);
            else if (Mathf.Abs(pos.y) > parentPanel.sizeDelta.y / 2 - rectTrans.sizeDelta.y / 2)
                JoystickPositionLimit(false, true);
        }

        rectTrans.anchoredPosition = new Vector3(pos.x * parentPanel.sizeDelta.x, pos.y * parentPanel.sizeDelta.y);
    }

    private void JoystickPositionLimit(bool isHorizontalOver, bool isVerticalOver)
    {
        if(isHorizontalOver)
            if (pos.x < 0)
                pos.x = -0.3f;
            else
                pos.x = 0.3f;
        else
            pos.x /= parentPanel.sizeDelta.x;

        if(isVerticalOver)
            if (pos.y < 0)
            pos.y = -0.3f;
        else
            pos.y = 0.3f;
        else
            pos.y /= parentPanel.sizeDelta.y;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        joystickState = JoystickState.NONE;
        joystickPreviousState = JoystickState.NONE;
        isDragControlButton = false;
        pos = Vector3.zero;
        rectTrans.anchoredPosition = Vector3.zero;
    }

    public void AddCommand(JoystickState buttonState)
    {
        if (joystickPreviousState != buttonState)
            joystickPreviousState = buttonState;
    }
}
