using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    private Rigidbody2D rb2d;
	private Vector2 movement;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float movehor = Input.GetAxis("Horizontal");
        float movver = Input.GetAxis("Vertical");
        movement = new Vector2(movehor, movver);
        rb2d.AddForce(movement*10);
	}
	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag ("PickUp")) {

			other.gameObject.SetActive (false);

			Vector2 temp = new Vector2 (100, 100);
			Vector3 temp2 = new Vector3 (0.1f,0.1f,0.1f);
			movement += temp;
			rb2d.AddForce(movement);
			rb2d.transform.localScale += temp2;

		}
	}

    
}
