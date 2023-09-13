using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEffect : MonoBehaviour
{

    public GameObject fire;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EngineOn()
    {
        Instantiate(fire, pointA.transform.position, pointA.transform.rotation,pointA.transform);
        Instantiate(fire, pointB.transform.position, pointB.transform.rotation,pointB.transform);
        Instantiate(fire, pointC.transform.position, pointC.transform.rotation,pointC.transform);
        Instantiate(fire, pointD.transform.position, pointD.transform.rotation,pointD.transform);
    }

    void EngineOff()
    {
        Destroy(pointA.transform.Find("FireEffect(Clone)").gameObject);
        Destroy(pointB.transform.Find("FireEffect(Clone)").gameObject);
        Destroy(pointC.transform.Find("FireEffect(Clone)").gameObject);
        Destroy(pointD.transform.Find("FireEffect(Clone)").gameObject);
    }
    void Ongravity()
    {
        transform.root.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
    void Offgravity()
    {
        transform.root.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
}
