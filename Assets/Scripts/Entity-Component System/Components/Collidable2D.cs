using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Collidable2D : JoshECSComponent {

	public float damageDone; //Damage done to other destructibles on collision.

	public Dictionary<Collidable2D, ContactPoint2D[]> collidersAndPoints = new Dictionary<Collidable2D, ContactPoint2D[]>();
	//public List<Collidable2D> currentColliders = new List<Collidable2D>();
	public Trigger2D currentTrigger;
	public bool isTriggerNew = false;


	void OnCollisionEnter2D(Collision2D col) {
		if (isActiveAndEnabled) {
			Collidable2D c = GetCollidable2D (col);
			if (c != null) { 
				//currentColliders.Add (c);
				collidersAndPoints.Add (c, col.contacts);
			}
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if (isActiveAndEnabled) {
			Collidable2D c = GetCollidable2D (col);
			if (c != null) { 
				//currentColliders.Remove (c);
				collidersAndPoints.Remove(c);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (isActiveAndEnabled) {
			Trigger2D c = col.gameObject.GetComponent<Trigger2D>();
			if (c != null) { 
				currentTrigger = c;
				isTriggerNew = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (isActiveAndEnabled) {
			currentTrigger = null;
		}
	}

	Collidable2D GetCollidable2D(Collision2D col) {
		return col.gameObject.GetComponent<Collidable2D>();
	}

	public override void UnregisterComponent() {
		base.UnregisterComponent();
		enabled = false;
		endCollision();
	}

	void endCollision() {
		foreach (Collidable2D collider in collidersAndPoints.Keys) {
			//collider.currentColliders.Remove (this);
			collider.collidersAndPoints.Remove (this);
		}

		//currentColliders.Clear();
		collidersAndPoints.Clear();
	}



}