using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Author: Aaron Curry
 */
public class Respawn : MonoBehaviour {

    private Rigidbody car;
   
    // Use this for initialization
    void Start () {

        car = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    { 
        if (car.position.z >= 1000)
        {
            // Destroy(gameObject);
            car.position = new Vector3 (507, car.position.y,10);
        }
    }
   

    // Update is called once per frame
    void Update () {
		
	}
}
