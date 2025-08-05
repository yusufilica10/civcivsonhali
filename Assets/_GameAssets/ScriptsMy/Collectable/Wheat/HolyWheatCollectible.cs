using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour , ICollectible
{

    [SerializeField] private WheatDesingSO _WheatDesignSO;
    [SerializeField] private PlayerController _PlayerController;

    [System.Obsolete]
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

        _PlayerController.SetPlayerJumpForce(_WheatDesignSO.IncreasedDecreaseMultiplier, _WheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
