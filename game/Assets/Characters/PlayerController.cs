using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.7f;
    public Transform skin;
    private void Start()
    {
        
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Obtém a entrada horizontal do jogador
        transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0f, 0f); // Move o personagem na direção horizontal
        run();
    }

    private void run(){
        if(Input.GetAxisRaw("Horizontal") != 0){
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1 ,1);
            skin.GetComponent<Animator>().SetBool("PlayerRunning", true);
        }else{
            skin.GetComponent<Animator>().SetBool("PlayerRunning", false);
        }
    }
}
