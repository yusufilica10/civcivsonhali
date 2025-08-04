using UnityEngine;



public class PlayerInteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // GOLD
        var gold = other.GetComponent<GoldwheatCollectible>();
        if (gold != null)
        {
            gold.Collect();
            Debug.Log("Gold Weath Collected");
            return;
        }

        // HOLY
        var holy = other.GetComponent<HolyWheatCollectible>();
        if (holy != null)
        {
            holy.Collect();
            Debug.Log("Holy Weath Collected");
            return;
        }

        // ROTTEN
        var rotten = other.GetComponent<RottenWheatCollectible>();
        if (rotten != null)
        {
            rotten.Collect();
            Debug.Log("Rotten Weath Collected");
            return;
        }

        // Hiçbiri deðilse logla
        Debug.LogWarning("Unknown object collided: " + other.name);
    }
}
