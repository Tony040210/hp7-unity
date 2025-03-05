using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f, jumpForce = 15f;
    [SerializeField] private int extraJumpCount = 2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    //private Animator animator;
    private bool isGrounded;
    private float jumps;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        //UpdateAnimation();
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (isGrounded) rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        Debug.DrawLine(transform.position, transform.position + new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 0));

        if (transform.position.y < -100)
        {
            transform.position = new Vector3(0, 10, 0);
            rb.linearVelocity = Vector2.zero;
        }
    }
    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            jumps = extraJumpCount;
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || (jumps > 0)))
        {
            jumps -= 1;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > .1f;
        bool isJumping = !isGrounded;

        //animator.SetBool("isRunning", isRunning);
        //animator.SetBool("isJumping", isJumping);
    }
}
