using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter(Collider hit)
    {
        InventoryItemBase item = hit.GetComponent<InventoryItemBase>();

        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

    //private void OnCollisionEnter(Collision hit)
    //{
    //    InventoryItemBase item = hit.collider.GetComponent<InventoryItemBase>();

    //    if (item != null)
    //    {
    //        inventory.AddItem(item);
    //    }
    //}
}
