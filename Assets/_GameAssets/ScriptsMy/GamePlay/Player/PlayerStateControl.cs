using UnityEngine;

public class PlayerStateControl : MonoBehaviour
{
    private PlayerState _currentState = PlayerState.Idle;



    private void Start()
    {
        
        ChangeState(PlayerState.Idle);  
    }


    public void ChangeState(PlayerState _newPlayerState) 
    {
        if(_currentState == _newPlayerState)
        {
            return; // No state change needed    // burada e�er karakterim idle da ise bo�u bo�una tekrar tekrar newplayerstateye d�n��t�rmesin
        }
        else
        {
           _currentState = _newPlayerState;

        }
            


    }

    public PlayerState GetCurrentState()
    {
        return _currentState;
    }
}
