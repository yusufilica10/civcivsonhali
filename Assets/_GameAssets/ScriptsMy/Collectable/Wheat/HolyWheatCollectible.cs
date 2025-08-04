using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _PlayerController;
    [SerializeField] private float _JumpBoost;
    [SerializeField] private float _BoostDuration;

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

        _PlayerController.SetPlayerJumpForce(_JumpBoost, _BoostDuration);
        Destroy(gameObject);
    }
}
