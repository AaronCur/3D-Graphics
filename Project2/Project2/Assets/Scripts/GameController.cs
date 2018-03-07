using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 *Author: Aaron Curry
 */
public class GameController : MonoBehaviour {

    public Text scoreText;
    private int score;
	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void UpdateScore () {

        scoreText.text = "Score: " + score;
	}

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
