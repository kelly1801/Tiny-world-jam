using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringSystem : MonoBehaviour
{
    // Gathering
    public GameObject gatheringObjectSelected;
    public bool isGathering;
    public float gatheringTimer;
    public Vector3 gatheringStartPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            collision.gameObject.SetActive(false);

        }
    }

}
