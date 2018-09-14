using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ControlButton controlButton;

    [Range(0.0f, 100f)]
    public float moveSpeed;

    private Animator playerAnimator;

    private bool isPlayerMove = false;
    private bool isPlayerTurn = false;
    private bool isPlayerWatchedRight = true;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (controlButton.joystickState == JoystickState.LEFT || controlButton.joystickState == JoystickState.RIGHT)
        {
            if (!isPlayerMove)
            {
                PlayerTurn();
                if (!isPlayerTurn)
                {
                    isPlayerMove = true;
                    playerAnimator.SetBool("isWalk", true);
                }
            }
            else
            {
                PlayerMoveClamp();
                transform.position += transform.right * moveSpeed * Time.deltaTime;
                PlayerTurn();
            }
        }
        else
            if (isPlayerMove)
        {
            isPlayerMove = false;
            playerAnimator.SetBool("isWalk", false);
        }
    }

    private void PlayerTurn()
    {
        if (controlButton.joystickState == JoystickState.LEFT)
        {
            if (isPlayerWatchedRight)
            {
                isPlayerTurn = true;
                playerAnimator.SetTrigger("isTurn");
            }
            isPlayerWatchedRight = false;
        }
        else if (controlButton.joystickState == JoystickState.RIGHT)
        {
            if (!isPlayerWatchedRight)
            {
                isPlayerTurn = true;
                playerAnimator.SetTrigger("isTurn");
            }
            isPlayerWatchedRight = true;
        }

        if (isPlayerTurn)
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn2"))
            {
                transform.rotation *= Quaternion.Euler(0, -180, 0);
                isPlayerTurn = false;
            }
        } else
        {
            isPlayerMove = true;
            playerAnimator.SetBool("isWalk", true);
        }
    }

    //플레이어 이동 제한
    private void PlayerMoveClamp()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.05f)
        {
            pos.x = 0.05f;
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        if(pos.x > 0.95f)
        {
            pos.x = 0.95f;
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}
