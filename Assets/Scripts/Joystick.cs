using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum JoystickState
{
    NONE,
    UP,
    DOWN,
    LEFT,
    RIGHT,
};

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;
    private JoystickState joystickState = JoystickState.NONE;

    //조이스틱 초기화
	private void Start () {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
	}

    //조이스틱을 드래그 할 때, 안 할 때 처리
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            if (inputVector.x >= -0.5f && inputVector.x <= 0.5f)
            {
                if (inputVector.y > 0)
                    joystickState = JoystickState.UP;
                else if (inputVector.y < 0)
                    joystickState = JoystickState.DOWN;
            }
            else if (inputVector.y >= -0.5f && inputVector.y <= 0.5f)
            {
                if (inputVector.x > 0)
                    joystickState = JoystickState.RIGHT;
                else if (inputVector.x < 0)
                    joystickState = JoystickState.LEFT;
            }

            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3),
                inputVector.y * (bgImg.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        joystickState = JoystickState.NONE;
    }

    //조이스틱의 방향값 받아올 때 호출하셈
    public float GetHorizontalValue()
    {
        return inputVector.x;
    }
    public float GetVerticalValue()
    {
        return inputVector.y;
    }
    
    //조이스틱의 상태를 받아올 때 호출하셈
    public JoystickState GetJoystickState()
    {
        return joystickState;
    }
}
