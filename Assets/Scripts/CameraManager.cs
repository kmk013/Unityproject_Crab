using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingleTon<CameraManager> {

    public Player player;
    public List<GameObject> objs = new List<GameObject>();

	void Update () {
        if (objs.Count == 0)
            CameraLerpPlayer();
	}

    private void CameraLerpPlayer()
    {
        if(player.controlButton.joystickState == JoystickState.RIGHT)
        {
            if(player.transform.position.x >= Camera.main.transform.position.x)
            {
                Camera.main.transform.position += Camera.main.transform.right * Time.deltaTime * player.moveSpeed;
            }
        }
    }
}
