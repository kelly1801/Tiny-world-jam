using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    // Start is called before the first frame update
    TextCreditsMovingGoingUpp textCreditsGoingUp;
    Animator animator;
    void Start()
    {
        textCreditsGoingUp = FindAnyObjectByType<TextCreditsMovingGoingUpp>();
        animator = GameObject.Find("PanelCredits").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 6.0f);
    }
    private void OnDestroy()
    {
        textCreditsGoingUp.isWinningTextDestroyed = true;
        if(animator != null)
        {
            animator.SetTrigger("isDestroyed");
        }
    }
}
