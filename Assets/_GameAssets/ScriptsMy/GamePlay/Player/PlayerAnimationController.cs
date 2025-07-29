using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    [SerializeField] private Animator _Playeranimator;

    private PlayerController _playerController;

    private PlayerStateControl _playerStateControl;



    private void Awake()
    {
        _playerStateControl = GetComponent<PlayerStateControl>();

        _playerController  = GetComponent<PlayerController>();


    }

    private void Start()
    {
        _playerController.OnPlayerJumped += PlayerController_OnPlayerJumped;
    }

 

    private void Update()
    {
        SetPlayerAnimation();
    }

    private void SetPlayerAnimation()
    {

        var _CurrentPlayerState = _playerStateControl.GetCurrentState();

        switch (_CurrentPlayerState)
        {
            case PlayerState.Idle:
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_JUMPING, false);
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING, false);

                break;
            case PlayerState.Move:
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING, false);
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_MOVE, true);

                break;
            case PlayerState.Jump:
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_JUMPING, true);
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING, false);
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_MOVE, false);
                break;
            case PlayerState.Slide:
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING_ACTIVE, true);
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING, true);
                break;
            case PlayerState.SlideIdle:
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING, true);
                _Playeranimator.SetBool(Const.PlayerAnimation.IS_SLIDING_ACTIVE, false);
                break;
        }
       
    }

    private void PlayerController_OnPlayerJumped()
    {

        _Playeranimator.SetBool(Const.PlayerAnimation.IS_JUMPING , true);
        Invoke(nameof(ResetJumpAnimation), 0.5f);
                    
    }

    private void ResetJumpAnimation()
    {
        _Playeranimator.SetBool(Const.PlayerAnimation.IS_JUMPING, false);
    }



}
