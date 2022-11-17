using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;

    public int score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;
    }
}
