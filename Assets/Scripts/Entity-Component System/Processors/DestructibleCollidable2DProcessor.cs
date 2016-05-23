using UnityEngine;
using System.Collections;

public class DestructibleCollidable2DProcessor : JoshECSProcessor<Destructible, Collidable2D> {

	protected override void Process(GameObject entity, Destructible destructible, Collidable2D collidable) {
		
		//Iterate through current colliders and apply damage
		foreach (Collidable2D collided in collidable.collidersAndPoints.Keys) {
			destructible.hitPoints.lose (collided.damageDone);
		}
	}


}
