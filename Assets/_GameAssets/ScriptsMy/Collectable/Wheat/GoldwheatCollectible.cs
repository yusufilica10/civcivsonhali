using UnityEngine;

public class GoldwheatCollectible : MonoBehaviour , ICollectible
{
    [SerializeField] private WheatDesingSO _WheatDesingSO;


    [SerializeField] private PlayerController _PlayerController;

   
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

        _PlayerController.SetPlayerMovementSpeed(_WheatDesingSO.IncreasedDecreaseMultiplier, _WheatDesingSO.ResetBoostDuration);
        Destroy(gameObject); // Destroy the collectible after collection
    }
}
