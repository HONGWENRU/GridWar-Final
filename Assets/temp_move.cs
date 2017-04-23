using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_move : MonoBehaviour {

	public GameObject player;

	private Vector3 off;

	private Vector3 temp;

	public GameObject Background;

	bool done=false;
	// Use this for initialization
	void Start () {
		 
		off = transform.position - player.transform.position; 
	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = player.transform.position + off;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (done == false) {
			if (other.gameObject.CompareTag ("background")) {


			
				//temp = player.transform.position - player.transform.position;

				//player.transform.position = temp;
				GameObject background = GameObject.Instantiate (Background);

				Vector3 temp = transform.position;
				temp.x -= 75.7f;
				background.transform.position = temp;
		        done = true;
			}
		}
	}
}
