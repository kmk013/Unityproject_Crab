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
            joystick.anchoredPosition = new Vector3(-660, -240, 0);
            commandButtons.anchoredPosition = new Vector3(585, -390, 0);
            
        }
        else
        {
            joystick.anchoredPosition = new Vector3(660, -240, 0);
            commandButtons.anchoredPosition = new Vector3(-585, -390, 0);
        }
    }
}
