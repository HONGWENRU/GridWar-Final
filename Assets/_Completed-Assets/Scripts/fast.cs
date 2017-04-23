using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fast : MonoBehaviour {
    public static int count;
    public GameObject faster;

    // Use this for initialization
    void Start () {
		faster.tag = "Fast";
	}
	
	// Update is called once per frame
	void Update () {
        if (count <= 8)
        {
			Vector3 position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
            GameObject clone = Instantiate(faster, position, transform.rotation);

            count++;
        }
    }
}
