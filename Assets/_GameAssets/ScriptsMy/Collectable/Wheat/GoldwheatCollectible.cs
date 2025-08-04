using UnityEngine;

public class GoldwheatCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _PlayerController;

    [SerializeField] private float _MovementIncreaseSpeed;

    [SerializeField] private float _ResetBoostDuration;

    public void Collect()
    {
        // Eðer atanmamýþsa sahnede bul
        if (_PlayerController == null)
        {
            _PlayerController = FindObjectOfType<PlayerController>();
        }

        // Hâlâ null ise logla ve devam etme
        if (_PlayerController == null)
        {
            Debug.LogError("PlayerController not found in scene!");
            return;
        }

        _PlayerController.SetPlayerMovementSpeed(_MovementIncreaseSpeed, _ResetBoostDuration);
        Destroy(gameObject); // Destroy the collectible after collection
    }
}
