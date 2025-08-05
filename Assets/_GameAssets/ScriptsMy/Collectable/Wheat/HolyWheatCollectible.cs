using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour , ICollectible
{

    [SerializeField] private WheatDesingSO _WheatDesignSO;
    [SerializeField] private PlayerController _PlayerController;

    [System.Obsolete]
    public void Collect()
    {
        // E�er atanmam��sa sahnede bul
        if (_PlayerController == null)
        {
            _PlayerController = FindObjectOfType<PlayerController>();
        }

        // H�l� null ise logla ve ��k
        if (_PlayerController == null)
        {
            Debug.LogError("PlayerController not found in scene for HolyWheatCollectible!");
            return;
        }

        _PlayerController.SetPlayerJumpForce(_WheatDesignSO.IncreasedDecreaseMultiplier, _WheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
