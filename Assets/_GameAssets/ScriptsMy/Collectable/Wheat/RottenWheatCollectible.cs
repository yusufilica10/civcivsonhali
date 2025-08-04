using UnityEngine;

public class RottenWheatCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _PlayerController;

    [SerializeField] private float _MovementDecreaseSpeed;

    [SerializeField] private float _ResetBoostDuration;



    public void Collect()
    {



        if(_PlayerController == null)
        {
            _PlayerController = FindObjectOfType<PlayerController>();
        }
        if (_PlayerController == null)
        {
            Debug.LogError("PlayerController not found in scene!");
            return;
        }

        _PlayerController.SetPlayerMovementSpeed(_MovementDecreaseSpeed, _ResetBoostDuration);
        Destroy(gameObject); // Destroy the collectible after collection




    }
}
