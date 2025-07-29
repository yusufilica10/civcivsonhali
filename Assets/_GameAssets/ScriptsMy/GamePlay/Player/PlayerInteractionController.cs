using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag(Const.WeathTypes.GOLD_WEATH))
        {
            
           Debug.Log("Gold Weath Collected");
            Destroy(other.gameObject);
        }
        if (other.CompareTag(Const.WeathTypes.HOLLY_WEATH))
        {

            Debug.Log("Holly Weath Collected");
            Destroy(other.gameObject);
        }

        if (other.CompareTag(Const.WeathTypes.ROTTEN_WEATH))
        {

            Debug.Log("Rotten Weath Collected");
            Destroy(other.gameObject);
        }



    }
}
