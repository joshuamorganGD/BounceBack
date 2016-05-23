using UnityEngine;
using System.Collections;

public class Collidable2DMobile2DProcessor : JoshECSProcessor<Collidable2D, Mobile2D> {

	protected override void Process(GameObject entity, Collidable2D collidable, Mobile2D mobile) {

		foreach (Collidable2D collided in collidable.collidersAndPoints.Keys) {
			
			ContactPoint2D contact = collidable.collidersAndPoints [collided] [0];
			mobile.velocity += new Vector3(contact.normal.x, contact.normal.y, 0) * 0.5f;
		}
	}

}
