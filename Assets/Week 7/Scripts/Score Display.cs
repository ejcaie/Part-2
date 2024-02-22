using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreLable;
    // Start is called before the first frame update
    void Start()
    {
        scoreLable = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreLable.text = Ball.score.ToString();
    }
}

