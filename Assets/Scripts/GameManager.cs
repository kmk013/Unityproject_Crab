using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager> {

    private GameSetting gameSetting;

    public bool isLeftHanded;
    
	void Start () {
        gameSetting = GetComponent<GameSetting>();

        isLeftHanded = true;
        
	}
	
	void Update () {
        gameSetting.HandedSetting(isLeftHanded);
    }
}
