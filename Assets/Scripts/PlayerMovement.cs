using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private float xMov, zMov;
    public float speed = 5.0f;
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
    public bool isTiny = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        originalScale = transform.localScale;
        Debug.Log(transform.localScale);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G) && currentTime >= nextTime)
        {
            ChangingLocalScale();
            nextTime = currentTime + delay;
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
            speed *= 1.5f;
            isTiny = true;
        }
        else
        {
            tr.localScale = originalScale;
            isTiny = false;
        }
    }
}
    