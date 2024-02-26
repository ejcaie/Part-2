using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointandClickPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public AnimationCurve fall;
    Vector2 movement;
    Vector2 destination;
    public float speed = 6f;
    float animationTime;
    public bool falling;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        falling = false;
    }

    private void FixedUpdate()
    {
        if (falling == true) return;

        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            animator.SetFloat("Movement", movement.magnitude);
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        if (rb.transform.position.x > destination.x)
        {
            animator.SetBool("FaceLeft", true);
        }
        if (rb.transform.position.x < destination.x)
        {
            animator.SetBool("FaceLeft", false);
        }
    }

    void Update()
    {
        if (falling == true) FallAnimation();

        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        falling = true;
    }

    void FallAnimation()
    {
        animationTime += Time.deltaTime * 2;
        float interpolation = fall.Evaluate(animationTime);
        if (transform.localScale.z < 0.1f)
        {
            Destroy(gameObject);
        }
        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
    }
}
