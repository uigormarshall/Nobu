using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 5.5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float sizeOfRaycastWall = 0.2f;
    [SerializeField] private Transform positionRaycastFooter;
    [SerializeField] private bool isFacingRight = true;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    private float moveInput;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateMoveInput();
        Run();
        Jump();
        OnGround();
        Flip();
    }

    private void UpdateMoveInput(){
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void Flip() {
       
        if ((moveInput < 0 && !isFacingRight) || (moveInput > 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void Run()
    {        
        RaycastHit2D wallCheck = Physics2D.Raycast(positionRaycastFooter.position, new Vector2(moveInput, 0f), sizeOfRaycastWall, groundLayer);
        Debug.DrawRay(positionRaycastFooter.position, new Vector2(moveInput, 0f), Color.blue, sizeOfRaycastWall);
        if (wallCheck.collider == null)
        {
            rigidBody2D.velocity = new Vector2(moveInput * moveSpeed, rigidBody2D.velocity.y);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(0f, rigidBody2D.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundLayer);
        Debug.DrawRay(transform.position,  Vector2.down, Color.red, 0.7f);
    }
}
