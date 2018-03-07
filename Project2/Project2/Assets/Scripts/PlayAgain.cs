using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Author: Aaron Curry
 */
public class PlayAgain : MonoBehaviour
{
    public void restart()
    {
       SceneManager.LoadScene("test scene");
    }
}
