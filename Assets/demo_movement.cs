using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    Rigidbody2D rb;

    Animator animator;

    public float timeToBlink;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.enabled = true;
        InvokeRepeating("blink", 1, timeToBlink);
    }

    // Update is called once per frame
    void Update()
    {
        float movX = SimpleInput.GetAxis("Horizontal");
    
        // Horizontal movement
        rb.velocity = new Vector2(movX * speed, rb.velocity.y);

        // Jump with input key
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    public void Jump()
    {
        // Set velocity instead of AddForce for more consistent jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    bool IsGrounded()
    {
        // Implement a check here to see if the player is touching the ground
        // You can use a raycast or a ground detection collider
        return true;
    }

    void blink()
    {
        animator.Play("blink_animation_name");  // Replace with your actual animation name
    }

}
