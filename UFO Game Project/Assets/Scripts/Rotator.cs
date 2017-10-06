using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {


    private Rigidbody2D rbpu;
    private float rad;

    public float rotaterSpeed;
    void Start()
    {
        rbpu = GetComponent<Rigidbody2D>();
        rbpu.useAutoMass = true;
        rad = Random.Range(0.2f, 2.0f);
        transform.localScale = new Vector3(rad, rad, 0);
        rbpu.useAutoMass = true;

    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

        float x = Random.Range(-2.0f,2.0f);
        float y = Random.Range(-2.0f,2.0f);
        Vector2 movement = new Vector2(x, y);
        rbpu.AddForce(movement * rotaterSpeed);

    }
}
