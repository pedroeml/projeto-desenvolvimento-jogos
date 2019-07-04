using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    SpriteRenderer spriteRendererTop;
    SpriteRenderer spriteRendererBottom;
    public Transform firePoint;
    bool facingRight;
    bool facingUp;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRendererTop = GameObject.Find("Top").GetComponent<SpriteRenderer>();
        spriteRendererBottom = GameObject.Find("Bottom").GetComponent<SpriteRenderer>();
        facingRight = true;
        facingUp = false;
    }

    bool IsGrounded()
    {
        return rb2d.IsTouching(GameObject.Find("Scenario").GetComponent<EdgeCollider2D>());
    }

    void FlipCharacter()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    void UpdateFirePointDirection()
    {
        if (facingUp)
        {
            firePoint.localPosition = new Vector3(-0.04f, 0.6f, 0f);
            firePoint.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else
        {
            firePoint.localPosition = new Vector3(0.5f, -0.05f, 0f);
            firePoint.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        facingUp = false;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(3.5f, rb2d.velocity.y);
            animator.SetBool("IsStanding", false);
            animator.SetBool("IsCrouching", false);

            if (!facingRight)
            {
                facingRight = true;
                FlipCharacter();
            }
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-3.5f, rb2d.velocity.y);
            animator.SetBool("IsStanding", false);
            animator.SetBool("IsCrouching", false);

            if (facingRight)
            {
                facingRight = false;
                FlipCharacter();
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("IsCrouching", false);
            animator.SetBool("IsAimingUp", false);
            animator.SetBool("IsStanding", true);
        }

        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);

            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                animator.SetBool("IsAimingUp", true);
                animator.SetBool("IsCrouching", false);
                facingUp = true;
            }
            else if (Input.GetKey("s") || Input.GetKey("down"))
            {
                animator.SetBool("IsCrouching", true);
                animator.SetBool("IsStanding", true);
                animator.SetBool("IsAimingUp", false);
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            }
            else if (Input.GetKey("space"))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 5.5f);
                animator.SetBool("IsCrouching", false);
                animator.SetBool("IsAimingUp", false);
                animator.SetBool("IsJumping", true);
            }
            
            animator.SetBool("IsShooting", Input.GetKey("j"));
        }

        UpdateFirePointDirection();
    }
}
