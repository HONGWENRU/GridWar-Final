using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_temp : MonoBehaviour {

	public void playbutto(string name){

		SceneManager.LoadScene (name);



	}

	public void play(){

		SceneManager.LoadScene (3);
	}

	public void exit(){
		Application.Quit ();
	}


}
