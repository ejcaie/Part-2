using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Ball : MonoBehaviour
{
    public GameObject KickOffSpot;
    public static float score = 0;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        rb.velocity = Vector2.zero;
        transform.position = KickOffSpot.transform.position;
    }
}
