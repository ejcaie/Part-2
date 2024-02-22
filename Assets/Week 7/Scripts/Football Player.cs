using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void OnMouseDown()
    {
        Selected(true);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected == true)
        {
            spriteRenderer.color = Color.red;
        }
    }
}
