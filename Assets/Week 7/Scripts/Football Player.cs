using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public float speed = 500;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        Selected(false);
    }

    public void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected == true)
        {
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            spriteRenderer.color= Color.red;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
