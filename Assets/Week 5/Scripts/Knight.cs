using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
    bool clickingOnSelf = false;
    float health;
    float maxHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
        if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && clickingOnSelf)
        {
            clickingOnSelf = true;
            SendMessage("TakeDamage");
            
        }
    }
    private void OnMouseUp()
    {
        clickingOnSelf = false;
        TakeDamage(1);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
    }
}
