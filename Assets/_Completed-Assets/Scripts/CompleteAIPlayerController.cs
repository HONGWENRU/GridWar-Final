using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteAIPlayerController : MonoBehaviour {
	public GameObject player;
	private float maxDistance = 12.0f;
	public float speed;
	private Rigidbody2D rb2d;
	private double xLimit = 10.0;
	private double yLimit = 10.0;
	private double xTotal = 0.0;
	private double yTotal = 0.0;
	private Vector3 direction = Vector3.up;
	private int directionIndex = 0;
	private Vector3[] directions = {Vector3.up, Vector3.right, Vector3.down, Vector3.left};
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		var targetPosition = player.transform.position;
		var distance = Vector2.Distance (transform.position, targetPosition);
		if (distance < maxDistance) {
			if (!smallerThan (player.transform)) {
				transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);			
			}
		} else {
			randomMove ();
		}
	}

	void randomMove(){
		var amttomove = speed * Time.deltaTime;
		direction = directions [directionIndex];
		if (directionIndex % 2 == 0) {
			yTotal += (amttomove * direction).y;
			if (yTotal > yLimit) {
				directionIndex = (directionIndex + 1) % 4;
				yTotal = 0;
			}
		}

		if (directionIndex % 2 == 1) {
			xTotal += (amttomove * direction).x;
			if (xTotal > xLimit) {
				directionIndex = (directionIndex + 1) % 4;
				xTotal = 0;
			}
		}
			
		transform.Translate(this.direction * amttomove);
	}

	void GenerateRandomDirection()
	{
		Vector2 v2  = Random.insideUnitCircle * 2;
		this.direction = new Vector3(v2.x, v2.y, 0.0f);
	}
		

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		switch (other.gameObject.tag) {
		case "Big":
			transform.localScale *= 1.2f;
			break;
		case "Small":
			transform.localScale *= 0.8f;
			break;
		case "Fast":
			speed *= 1.2f;
			break;
		case "Slow":
			speed *= 0.8f;
			break;
		default:
			break;
		}

		other.gameObject.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (smallerThan(other.gameObject.transform)) {
				Destroy (transform.root.gameObject);
				other.gameObject.transform.localScale = other.gameObject.transform.localScale * 1.1f;
			} else {
				SceneManager.LoadScene ("gameover");

			}
		}  
		if (other.gameObject.CompareTag("Maze")) {
			directionIndex = (directionIndex + 2) % 4;
			xTotal = 0;
			yTotal = 0;
		}
		if (other.gameObject.CompareTag ("Bomb")) {
			transform.localScale = transform.localScale * 0.3f;
			Destroy (other.gameObject);
		}
	}

	bool smallerThan(Transform other) {
		var newScale = other.localScale;
		return Mathf.Abs (newScale.x * newScale.y) - Mathf.Abs (transform.localScale.x * transform.localScale.y) > 0;
	}

}
