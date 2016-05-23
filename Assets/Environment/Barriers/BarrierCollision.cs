using UnityEngine;
using System.Collections;

public class BarrierCollision : MonoBehaviour {

	public float exitPointX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerEnter2D(Collider2D col) {
		col.transform.position = new Vector3 (exitPointX, col.transform.position.y, 0);
		col.attachedRigidbody.angularVelocity *= 1.1f;
	}*/
}
