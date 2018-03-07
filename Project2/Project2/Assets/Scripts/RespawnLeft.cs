using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Author: Aaron Curry
 */
public class RespawnLeft : MonoBehaviour {

    private Rigidbody car;
    public GameObject explosion;
    public GameObject pexplosion;
    public int scoreValue;

    private GameController gameController;

    // Use this for initialization
    void Start () {

        car = GetComponent<Rigidbody>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'gameController' script");
        }
    }

    void FixedUpdate()
    { 
        if (car.position.z >= 1000)
        {
            // Destroy(gameObject);
            car.position = new Vector3 (500, car.position.y,20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Bolt" && tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            car.position = new Vector3(500, car.position.y, 20);
            gameController.AddScore(100);

        }
        if (other.tag == "Bolt" && tag != "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            car.position = new Vector3(500, car.position.y, 20);
            gameController.AddScore(-50);
        }
        if (other.tag == "Player" && tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(pexplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.AddScore(200);
            Debug.Log("Enemy");
            SceneManager.LoadScene("GameOver");
        }
        if (other.tag == "Player" && tag != "Enemy")
        {
            Instantiate(pexplosion, transform.position, transform.rotation);
            car.position = new Vector3(515, car.position.y, 20);
            Debug.Log("Norm");
            gameController.AddScore(-50);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
