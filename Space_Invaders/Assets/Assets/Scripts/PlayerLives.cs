//Name: Aaron Curry
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour {
    public static float life = 3;
    private Text livesText;
	// Use this for initialization
	void Start () {
        livesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "Lives: " + life;
	}
}
