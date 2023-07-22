using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;

    void Start()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateStatus();
        Running();
        Jumping();
    }

    private void UpdateStatus(){
        animator.SetBool("isGrounded", player.isGrounded);
        animator.SetBool("jumping", player.isJumping);
        animator.SetBool("isFallen", player.isFallen);
        animator.SetBool("running", player.isRunning);
        animator.SetBool("isLowered", player.isLowered);
    }
    void Running(){
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
            animator.SetBool("running", true);
        else
            animator.SetBool("running", false);
    }

   void Jumping(){
        if (player.isJumping)
        {
            animator.SetBool("jumping", true);
            animator.SetBool("isGrounded", player.isGrounded);
        }
    }

    private void Lowered()
    {
        if(player.isLowered && player.isGrounded){
            animator.SetBool("isLowered", true);
            animator.SetBool("running", false);
        }
    }
    public void JumpAnimator()
    {
        player.JumpAnimator();
    }
}
