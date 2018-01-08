//Name: Aaron Curry
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControler : MonoBehaviour {

    private Rigidbody rb;
    private Transform player;
    public float speed;
    public float minBound;
    public float maxBound;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
          float h = Input.GetAxis("Horizontal");

           if (player.position.x < minBound && h < 0)
          {
            h = 0;
         }
         else if (player.position.x > maxBound & h > 0)
         {
          h = 0;
         }

         player.position += Vector3.right * h * speed;


    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
