using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.7f;
    public float jumpForce = 5f;
    public int doubleJumpCount = 0;
    public Transform skin;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Obtém a entrada horizontal do jogador
        transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0f, 0f); // Move o personagem na direção horizontal
        run();
        jump();
    }

    private void run(){
        if(Input.GetAxisRaw("Horizontal") != 0){
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1 ,1);
            skin.GetComponent<Animator>().SetBool("PlayerRunning", true);
        }else{
            skin.GetComponent<Animator>().SetBool("PlayerRunning", false);
        }
    }

    private void jump(){
        if (Input.GetButtonDown("Jump") && NotJumping() )
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private bool NotJumping(){
        if(Mathf.Abs(rb.velocity.y) < 0.001f){
            return true;
        }
        return false;
    }
}
