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

    /*
     * if ( Esta tocando el arbol ){
     *      Presiona SPACE_BAR para recolectar
     * }
     * 
     * if (! Esta recolectando){
     *      print ("Started Gathering");
     *      gatheringObjectSelected = other.transform.gameObject;
     *      gatheringStartPos = this.transform.position;
     *      gatheringTimer = 3.0f;
     *      isGathering = true;
     * }
     * 
     */

    /*
     * if (isGathering){
     * 
     *  if(GatheringTimer > 0){
     *      GatheringTimer -= Time.deltaTime;
     *  } else {
     *      print ("Gathered the item");
     *      isGathering = false;
     *      Destroy (gatheringObjectSelected.gameObject);
     *      }
     * 
     * if (this.transform.position != GatheringStartPos){
     *      isGathering = false;
     *      print ("Player moved while gathering");
     *  }
     * }
     */
}
