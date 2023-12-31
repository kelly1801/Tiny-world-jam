using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private float xMov, zMov;
    public float speed = 20f;
    private float delay = 3.0f;
    public float jumpForce = 50000.0f;
    public float fallForce = 40000.0f;
    private float gradeMultiply;

    private float nextTime;
    private float currentTime;

    public bool isScene1;
    public bool isScene2;

    // Components
    private Rigidbody rb;
    private Transform tr;

    // Vectors
    private Vector3 tinyScale = new(0.5f, 0.5f, 0.5f);
    private Vector3 originalScale;
    private Vector3 moveInput;

    // Quater
    Quaternion rotateInput;

    // Bools
    public bool isTiny = false;
    private bool isPauseMenuDisplay = false;
    [SerializeField] private bool isGrounded;

    // Gameobjects to interact with
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject Planet1;

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
        GravityPhysics();

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jumping();
        }
        if (Input.GetKeyDown(KeyCode.X) && isGrounded == false)
        {
            pushDown();
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
        moveInput = new Vector3(xMov, moveInput.y, zMov);
        Vector3 directionToMove = rb.transform.rotation * moveInput;
        rotateInput = Quaternion.Euler(rotateInput.x, xMov * gradeMultiply, rotateInput.z);
        rb.velocity = (directionToMove * speed);
    }
    void ChangingLocalScale()
    {
        if(isTiny == false)
        {
            tr.localScale = tinyScale;
            speed *= 3f;
            isTiny = true;
        }
        else
        {
            tr.localScale = originalScale;
            speed /= 3f;
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

    void Jumping()
    {
        rb.AddForce((transform.up * jumpForce *  Time.deltaTime),ForceMode.Impulse);
    }

    void GravityPhysics()
    {
        if (isScene1 == true)
        {
            Physics.gravity = Planet1.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;

        }
    }
    void pushDown()
    {
        rb.AddForce(Vector3.down * fallForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
    