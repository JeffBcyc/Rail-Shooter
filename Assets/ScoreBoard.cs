using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    Text currentScore;
    int score;

    private void Awake()
    {
        currentScore = FindObjectOfType<Text>();
        //currentScore.text = currentScore.ToString();
        currentScore.text = "0";

        // make it a singleton so that player can have 3 lives to add points together
        int numOfScoreBoard = FindObjectsOfType<ScoreBoard>().Length;


        if (numOfScoreBoard > 1)
        {
            Destroy(this.transform.root.gameObject);
        } else
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }

    }

    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        currentScore.text = score.ToString();
    }

}
