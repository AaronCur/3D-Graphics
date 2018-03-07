using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *Author: Aaron Curry
 */

public class ChangeScene : MonoBehaviour {

	public void changeScene(string NewGame)
	{
		//Load new scene
		SceneManager.LoadScene(NewGame);
	}
}