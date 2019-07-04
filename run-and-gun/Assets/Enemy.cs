using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public int health = 100;
    float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 && !animator.GetBool("IsDead"))
        {
            animator.SetBool("IsDead", true);
            SoundManagerScript.PlaySound("scream");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Die();
            rb2d.velocity = new Vector2(3.5f, rb2d.velocity.y);
        }
    }

    void Die()
    {
        Destroy(gameObject, lifetime);
    }
}
