using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public float timer;
    void Start()
    {
        slider.value = 0;
    }

    void FixedUpdate()
    {
        slider.value += (Time.deltaTime * 0.05f);
        timer = slider.value;
        if (timer == 1)
        {
            SendMessage("LoadMenuScene", SendMessageOptions.DontRequireReceiver);
        }
    }
}
