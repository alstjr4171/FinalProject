using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded;
    private bool isGameover = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isGameover)
        {
            return;
        }
        float moveInput = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(moveInput * moveSpeed, playerRigidbody.velocity.y);
        if (moveInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            animator.SetTrigger("isJumping");
        }
        FlipSprite();
    }
    void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(playerRigidbody.velocity.x), 1f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeadZone")
        {
            Die();
        }
        else if (other.gameObject.name == ("Spike"))
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("isDead");

        isGameover = true;

        GameManager.Instance.OnPlayerDead();
    }
    
}
