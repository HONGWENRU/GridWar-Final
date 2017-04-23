using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour {
    public static int count;
    public GameObject pickup;
	// Use this for initialization
	void Start () {
		pickup.tag = "Slow";
	}
	
	// Update is called once per frame
	void Update () {
        if (count <= 8) {
			Vector3 position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
            GameObject clone = Instantiate(pickup, position, transform.rotation);

            count++;
        }

	}
}
