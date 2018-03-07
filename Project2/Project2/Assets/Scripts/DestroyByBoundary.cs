using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Author: Aaron Curry
 */

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
        }
    }

}