using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ScoreText;

    [SerializeField]
    private TMP_Text HighScoreText;

    public static Score instance;
    [SerializeField]
    private float score;
    [SerializeField]
    private float highScore;
    [SerializeField]
    private float temp;

    public static bool Dash = false;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("highscore1", 0);

        HighScoreText.text = "HighScore: " + highScore.ToString();
    }

    public void ScoreUp()
    {
        highScore = PlayerPrefs.GetFloat("highscore1", 0);

        HighScoreText.text = "HighScore: " + highScore.ToString();

        temp++;
        if(temp > 10 && Dash == true)
        {
            temp = 80;
        }
        if (temp == 80)
        {
            temp /= 80;
            score++;
            AudioManager.instance.PlaySFX("Point");
        }
        ScoreText.text = score.ToString();

        if (score > highScore)
        {

            PlayerPrefs.SetFloat("highscore1", score);
        }
        HighScoreText.text = "HighScore: " + highScore.ToString();

    }
}
