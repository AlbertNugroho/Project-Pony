using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    [Header("Item Drop Settings")]
    public List<GameObject> dropItems;
    [Range(0f, 1f)]
    public float dropChance = 0.2f;

    public void TryDropItem()
    {
        if (dropItems.Count == 0) return;

        float roll = Random.value;
        if (roll <= dropChance)
        {
            GameObject itemToDrop = dropItems[Random.Range(0, dropItems.Count)];
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }
}