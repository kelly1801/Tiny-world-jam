using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private float xMov, zMov;
    [SerializeField] private float speed = 5.0f;
    private float delay = 3.0f;

    private float nextTime;
    private float currentTime;

    // Components
    private Rigidbody rb;
    private Transform tr;

    // Vectors
    private Vector3 tinyScale = new(0.5f, 0.5f, 0.5f);
    private Vector3 originalScale;

    // Bools
    [SerializeField] private bool isTiny = false;
    [SerializeField] private bool isPauseMenuDisplay = false;

    // Gameobjects to interact with
    [SerializeField] private GameObject pauseMenu;
    
    // Others


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        originalScale = transform.localScale;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G) && currentTime >= nextTime)
        {
            ChangingLocalScale();
            nextTime = currentTime + delay;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && isPauseMenuDisplay == false)
        {
            ActiveMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPauseMenuDisplay == true)
        {
            DeactiveMenu();
        }
    }

    private void FixedUpdate()
    {
        Movement();        
    }

    void Movement()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xMov * speed, rb.velocity.y, zMov * speed);
    }
    void ChangingLocalScale()
    {
        if(isTiny == false)
        {
            tr.localScale = tinyScale;
            isTiny = true;
        }
        else
        {
            tr.localScale = originalScale;
            isTiny = false;
        }
    }

    void ActiveMenu()
    {
            pauseMenu.SetActive(true);
            isPauseMenuDisplay = true;
            Time.timeScale = 0.0f;
    }

    public void DeactiveMenu()//MANDATORY TIENE QUE SER PUBLICO O SI NO UI RESUME BUTTON NO FUNCIONA.
    {
            pauseMenu.SetActive(false);
            isPauseMenuDisplay = false;
            Time.timeScale = 1.0f;
    }
}
    