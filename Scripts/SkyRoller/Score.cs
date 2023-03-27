using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text highScore;

    public float scoreAmount;
    public float pointIncreasedPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        highScore.text = PlayerPrefs.GetFloat("Highscore", 0).ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<BallController>().started == true)
        {
            scoreText.text = scoreAmount.ToString("0");
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

            HighScore();
        }
        
    }

    public void HighScore()
    {
        if(scoreAmount > PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", scoreAmount);
            highScore.text = scoreAmount.ToString("0");
        }
        
    }

}
