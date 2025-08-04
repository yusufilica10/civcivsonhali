using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _PlayerController;
    [SerializeField] private float _JumpBoost;
    [SerializeField] private float _BoostDuration;

    public void Collect()
    {
        // Eðer atanmamýþsa sahnede bul
        if (_PlayerController == null)
        {
            _PlayerController = FindObjectOfType<PlayerController>();
        }

        // Hâlâ null ise logla ve çýk
        if (_PlayerController == null)
        {
            Debug.LogError("PlayerController not found in scene for HolyWheatCollectible!");
            return;
        }

        _PlayerController.SetPlayerJumpForce(_JumpBoost, _BoostDuration);
        Destroy(gameObject);
    }
}
