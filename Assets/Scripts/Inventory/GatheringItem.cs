using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringItem : MonoBehaviour
{
    private float respawnTime = 3.0f;
    void RespawnMaterialDispenser()
    {
        if (gameObject.activeSelf == false)
        {
            Invoke("RespawnItem", respawnTime);
        }
    }

    void RespawnItem()
    {
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        RespawnMaterialDispenser();
    }
}
