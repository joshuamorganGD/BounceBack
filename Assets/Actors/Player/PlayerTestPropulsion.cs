using UnityEngine;
using System.Collections;

public class PlayerTestPropulsion : MonoBehaviour {

	Rigidbody2D target;

	// Use this for initialization
	void Start () {
		target = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			target.transform.Rotate (0, 0, Input.GetAxis ("Horizontal") * -2.5f);
		}

		target.AddForce (target.transform.up * -Input.GetAxis ("LR Trigger") * 50f);
	}
}
