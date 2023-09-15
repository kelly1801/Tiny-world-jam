using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] Animator rleg;
    [SerializeField] Animator lleg;
    [SerializeField] Animator head;
    [SerializeField] Animator lid;
    [SerializeField] Animator engine;


    private float angryLevel = 100f;
    private bool isLidOpen = false;
    public float minDelay = 1f; // Minimum delay in seconds
    public float maxDelay = 5f; // Maximum delay in seconds

    private NavMeshAgent enemyAgent;
    public Transform objectivePosition;
    private AudioSource audioSource;
    [SerializeField] private AudioClip deniedAccessClip;
    [SerializeField] private AudioClip grantedAccessClip;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        StartEnemy();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(RandomlyToggleLid());
    }

    void Update()
    {
        enemyAgent.destination = objectivePosition.position;

        if (angryLevel == 0)
        {
            Pacify();
        }

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


    private void ChangeAngryLevel()
    {
        if (isLidOpen)
        {
            angryLevel -= 33;
            audioSource.PlayOneShot(grantedAccessClip);
            Debug.Log("Yeeeeeeeeeeeeees");
        } else
        {
            angryLevel += 33;
            audioSource.PlayOneShot(deniedAccessClip);
            Debug.Log("Noooooooooooooo");
        }
       
    }

    private void StartEnemy()
    {
        OpenLegs();
        TurnOnEngine();
        StartWalking();
    }
    private void Pacify()
    {
        FoldLegs();
        StopWalking();
        TurnOffEngine();
        StopWalking();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
   
            ChangeAngryLevel();
            Debug.Log("Nooooow");
           
        }
    }

    //animation methods
    void StartWalking()
    {
        rleg.SetBool("walk", true);
        lleg.SetBool("walk", true);
    }

    void StopWalking()
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

    void TurnOnEngine()
    {
        engine.SetBool("ON", true);
    }

    void TurnOffEngine()
    {
        engine.SetBool("ON", false);
    }

    void OpenLegs()
    {
        rleg.SetBool("open", true);
        lleg.SetBool("open", true);
    }

    void FoldLegs()
    {
        rleg.SetBool("open", false);
        lleg.SetBool("open", false);
    }
}

