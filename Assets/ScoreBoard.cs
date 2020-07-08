using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    [SerializeField] int eachEnemyPoints = 100;
    Text currentScore;
    int score;

    private void Awake()
    {
        currentScore = FindObjectOfType<Text>();
        currentScore.text = currentScore.ToString();

        // make it a singleton so that player can have 3 lives to add points together
        int numOfScoreBoard = FindObjectsOfType<ScoreBoard>().Length;
        if (numOfScoreBoard > 1)
        {
            Destroy(this);
        } else
        {
            currentScore.text = "0";
            print(Convert.ToInt32("0"));
            DontDestroyOnLoad(this);
        }

    }

    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        currentScore.text = score.ToString();
    }

}
