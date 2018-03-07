using UnityEngine;
using System.Collections;
/*
 *Author: Aaron Curry
 */
public class Mover : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

    }


}
