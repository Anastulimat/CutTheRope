using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TriggerAnimation.isHungry)
        {
            animator.Play("Hungry");
        }
        else if (TriggerAnimation.isEating)
        {
            animator.Play("Eat");
        }
        else if (TriggerAnimation.isSad)
        {
            animator.Play("Sad");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
