using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    //[SerializeField] private Movement movement;
    [SerializeField] private Animator animator;
    void Start()
    {
        //movement = GetComponentInParent<Movement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Running();
    }

    void Running(){
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
            animator.SetBool("running", true);
        else
            animator.SetBool("running", false);
        Debug.Log(moveInput);
    }
}
