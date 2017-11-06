//Name: Aaron Curry
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour {

    public float health = 10;
    public bool playAudio = false;
	// Update is called once per frame
	void Update () {
    
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (playAudio == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            playAudio = false;
        }
		
	}
   
}
