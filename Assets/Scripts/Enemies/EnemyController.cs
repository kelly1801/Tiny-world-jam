using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject fire;
    public Animator rleg;
    public Animator lleg;
    public Animator head;
    public Animator lid;
    public Animator engine;
    public float xMov = 1;
    public float zMov = 1;
    public float speed = 5.0f;
    Rigidbody rb;
    private float angryLevel = 5f;
    public bool isLidOpen = false;
    public float minDelay = 1f; // Minimum delay in seconds
    public float maxDelay = 5f; // Maximum delay in seconds
    private NavMeshAgent enemyAgent;
    public Transform objectivePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyAgent = GetComponent<NavMeshAgent>();
        Openlegs();
        Onengine();
        Walkstart();
        StartCoroutine(RandomlyToggleLid());
    }

    // Update is called once per frame
    void Update()
    {
        //OPEN and CLOSE LEGs

        enemyAgent.destination = objectivePosition.position;
    if (angryLevel == 0) {
            Foldlegs();
            Stopwalk();
            Offengine();
            Stopwalk();
        }   

    }

    void Openlegs()
    {
        rleg.SetBool("open", true);
        lleg.SetBool("open", true);
    }
    void Foldlegs()
    {
        rleg.SetBool("open", false);
        lleg.SetBool("open", false);
    }
    void Onengine()
    {
        engine.SetBool("ON", true);
    }
    void Offengine()
    {
        engine.SetBool("ON", false);
    }

    
    private IEnumerator RandomlyToggleLid()
    {
        while (true)
        {
            float randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);

            if (isLidOpen)
            {
                CloseLid();
                isLidOpen = false;
            }
            else
            {
                OpenLid();
                isLidOpen = true;
            }

        }
    }
    void Walkstart()
    {
        rleg.SetBool("walk", true);
        lleg.SetBool("walk", true);
        rb.velocity = new Vector3(xMov * speed, rb.velocity.y, zMov * speed);
    }
    void Stopwalk()
    {
        rleg.SetBool("walk", false);
        lleg.SetBool("walk", false);
    }

    void OpenLid()
    {
        lid.SetBool("open", true);
    }

    void CloseLid()
    {
        lid.SetBool("open", false);
    }
}

