using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCreditsMovingGoingUpp : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    public bool isWinningTextDestroyed = false;
    Animator animatorDown;
    Animator animatorUp;
    Animator buttonAnim;

    void Start()
    {
        animatorDown = GameObject.Find("MainTitleDown").GetComponent<Animator>();
        animatorUp = GameObject.Find("MainTitleUp").GetComponent<Animator>();
        buttonAnim = GameObject.Find("StartAgainButton").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWinningTextDestroyed == true) transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= 680.0f) Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        animatorDown.SetTrigger("CreditsDestroyed");
        animatorUp.SetTrigger("CreditsDestroyed");
        buttonAnim.SetTrigger("CreditsDestroyed");
    }
}
