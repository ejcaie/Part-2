using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{

    public GameObject plane;
    public float timerValue;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(plane);
        timerValue = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerValue <= 0)
        {
            Instantiate(plane);
            timerValue = Random.Range(1, 5);
        }
        timerValue -= 1f*Time.deltaTime;
    }
}
