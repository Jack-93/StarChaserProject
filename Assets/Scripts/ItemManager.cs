using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ������ ����
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
