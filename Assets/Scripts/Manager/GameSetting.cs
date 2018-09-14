using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour {

    public RectTransform joystick;
    public RectTransform commandButtons;

    public void HandedSetting(bool isLeftHanded)
    {
        if(isLeftHanded)
        {
            commandButtons.anchoredPosition = new Vector3(585, -390, 0);
        }
        else
        {
            commandButtons.anchoredPosition = new Vector3(-585, -390, 0);
        }
    }
}
