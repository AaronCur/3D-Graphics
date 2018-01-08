//Name: Aaron Curry
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    private Transform bullet;
    public float speed;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Transform>();
	}
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }

    }
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player")
        {
            PlayerLives.life -= 1;

            if (PlayerLives.life == 0)
            {
                
                Destroy(other.gameObject);
                GameOver.isPlayerDead = true;
            }
            
            Destroy(gameObject);

        }
        else if (other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            baseHealth.playAudio = true;
            Destroy(gameObject);
        }
	}
}
