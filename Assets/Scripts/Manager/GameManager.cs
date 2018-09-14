using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JoystickState
{
    NONE,
    UP,
    DOWN,
    LEFT,
    RIGHT,
};

public class GameManager : SingleTon<GameManager> {

    private GameSetting gameSetting;

    public float score;
    public bool isLeftHanded;
    
	private void Start () {
        gameSetting = GetComponent<GameSetting>();

        isLeftHanded = true;
        
	}
	private void Update () {
        gameSetting.HandedSetting(isLeftHanded);
    }

    public bool IsOutScreen(Vector3 nowPosition)
    {
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(nowPosition);
        if (targetScreenPos.x > Screen.width || targetScreenPos.x < 0 || targetScreenPos.y > Screen.height || targetScreenPos.y < 0)
            return true;
        else return false;
    }
}
