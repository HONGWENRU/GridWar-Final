﻿using UnityEngine;
using System.Collections;

public class AIPlayerGenerator : MonoBehaviour {
	private int count = 0;
	public GameObject AIPlayer;
	public GameObject player;
	public int number;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (count <= number) {
			float x = Random.Range (-40, 40);
			float y = Random.Range (-40, 40);
			Vector3 v = new Vector3 (x, y, 0);
			if (Vector2.Distance (v, player.transform.position) > 15f) {
				GameObject gobj = Instantiate (AIPlayer, v, transform.rotation);
				count++;
			}
		}
	}
}

