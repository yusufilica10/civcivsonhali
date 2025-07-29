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
            return; // No state change needed    // burada eðer karakterim idle da ise boþu boþuna tekrar tekrar newplayerstateye dönüþtürmesin
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
