using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rbGoalkeeper;
    Vector2 direction;
    float mag;
    public float radius = 2.3f;
 
    void Update()
    {
        if (Controller.SelectedPlayer == null) return;

        direction = (Vector2)transform.position - (Vector2)Controller.SelectedPlayer.transform.position;
        mag = direction.magnitude;
        direction.Normalize();
    }
    private void FixedUpdate()
    {
        if(mag / 2 < radius)
        {
            rbGoalkeeper.position = (Vector2)transform.position - direction * mag / 2;
        }
        else
        {
            rbGoalkeeper.position = (Vector2)transform.position - direction * radius;
        }
    }
}
