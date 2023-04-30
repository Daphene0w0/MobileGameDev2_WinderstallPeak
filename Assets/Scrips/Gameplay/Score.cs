using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text currentScoreText;

    public float score = 0f;
    public int scoreDivide = 2;

    public float currentScore;
    public float highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        currentScoreText.text = currentScore.ToString();

        highScoreText.text = PlayerPrefs.GetFloat("HighScore",0).ToString("#");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerIsDead") != 1)
        {
            score += Time.deltaTime * 3f;
            scoreText.text = score.ToString("#");
        }

        if (PlayerPrefs.GetInt("PlayerIsDead") == 1)
        {
            if (score > PlayerPrefs.GetFloat("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", score);
                highScoreText.text = score.ToString("#");
            }
        }

        if (PlayerPrefs.GetInt("PlayerIsDead") == 1)
        {
            PlayerPrefs.SetFloat("currentScore", score);
            currentScore = score;
            currentScoreText.text = score.ToString("#");

        }

    }

}
