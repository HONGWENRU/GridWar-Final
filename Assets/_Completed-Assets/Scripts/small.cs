using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class small : MonoBehaviour {
    public static int count;
    public GameObject smaller;

    // Use this for initialization
    void Start () {
		smaller.tag = "Small";
	}
	
	// Update is called once per frame
	void Update () {
        if (count <= 8)
        {
			Vector3 position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
            GameObject clone = Instantiate(smaller, position, transform.rotation);
            count++;
        }
    }
}
