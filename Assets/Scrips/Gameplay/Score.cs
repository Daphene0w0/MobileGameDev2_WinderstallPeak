using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //PlayerBehaviour playerBehaviour;

    public Text scoreText;
    //public TMP_Text highScoreText;

    public float score = 0f;
    //public int highScore = 0;
    public int scoreDivide = 2;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        //highScoreText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerIsDead") != 1)
        {
            score += Time.deltaTime * 3f;
            scoreText.text = score.ToString("#");
        }
    }
}
