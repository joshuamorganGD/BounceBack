using UnityEngine;
using System.Collections;
using System.Linq;

public class DestructibleDestroyedProcessor : JoshECSProcessor<Destructible, Destroyed> {

	protected override void Process(GameObject entity, Destructible destructible, Destroyed destroyed) {

		//Instantiate Debris
		foreach (Mobile2D debrisObj in destructible.debris) {
			GameObject debris = GameObject.Instantiate (debrisObj.gameObject, entity.transform.position, entity.transform.rotation) as GameObject;
			debris.GetComponent<Mobile2D> ().velocity = new Vector3 (Random.Range (-2, 2), Random.Range (-2, 2), 0);
		}

		if (destructible.debrisEffect != null) {
			
			GameObject.Instantiate (destructible.debrisEffect, 
				new Vector3 (entity.transform.position.x, entity.transform.position.y, entity.transform.position.z - 1),
				entity.transform.rotation);
		}

		//Hide yourself
		entity.GetComponent<SpriteRenderer>().enabled = false;
	}
}
