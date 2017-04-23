using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour {

	public void win_back(string name){
	
		SceneManager.LoadScene(name);
	
	}
}
