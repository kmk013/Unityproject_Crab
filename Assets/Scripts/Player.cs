using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour {

    [Range(0.0f, 2.5f)]
    public float moveSpeed;

    private Joystick joystick;
    private Animator playerAnimator;

	private void Start () {
        joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
        playerAnimator = GetComponent<Animator>();
	}

    private void Update () {
        PlayerControl();
        PlayerRotationAnimation();
    }

    //조이스틱을 이용한 플레이어 컨트롤 함수
    private void PlayerControl()
    {
        if (joystick.GetJoystickState() != JoystickState.NONE)
        {
            PlayerMoveClamp();
            transform.Translate(new Vector3(joystick.GetHorizontalValue(), 0, 0).normalized * moveSpeed * Time.deltaTime);
            if (joystick.GetHorizontalValue() > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Camera.main.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else if (joystick.GetHorizontalValue() < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    //플레이어 이동 범위 제한
    private void PlayerMoveClamp()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //플레이어 애니메이션 전환 함수
    private void PlayerRotationAnimation()
    {
        playerAnimator.SetInteger("JoystickState", (int)joystick.GetJoystickState());
    }
}
