using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCreditsMovingGoingUpp : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    public bool isWinningTextDestroyed = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isWinningTextDestroyed == true) transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
