using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Author: Aaron Curry
 */
public class CameraRespawn : MonoBehaviour
{

    private Rigidbody cam;

    // Use this for initialization
    void Start()
    {

        cam = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (cam.position.z >= 990)
        {
            // Destroy(gameObject);
            cam.position = new Vector3(cam.position.x, cam.position.y, 90);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
