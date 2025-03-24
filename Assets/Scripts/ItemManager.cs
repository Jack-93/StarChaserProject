using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* æ∆¿Ã≈€ Ω∫∆Â
 * 1. 
 */
public class ItemManager : MonoBehaviour
{
    public string itemName;
    public int itemValue;
    public void Collect()
    {
        Debug.Log($"Collected: {itemName}");
        GameManager.Instance.score += itemValue;
        Destroy(gameObject);
    }

}
