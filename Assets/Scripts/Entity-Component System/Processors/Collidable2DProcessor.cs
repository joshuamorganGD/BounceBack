using UnityEngine;
using System.Collections;

public class Collidable2DProcessor : JoshECSProcessor<Collidable2D> {

	protected override void Process(GameObject entity, Collidable2D collidable) {

		ProcessTrigger (entity, collidable);
		ProcessColliders (entity, collidable);

	}

	void ProcessColliders(GameObject entity, Collidable2D collidable) {
		//No nothing
	}

	void ProcessTrigger(GameObject entity, Collidable2D collidable) {

		//Apply Trigger Behaviours
		if (collidable.currentTrigger != null && collidable.isTriggerNew) {

			Trigger2D.TriggerBehaviour tbehaviour = collidable.currentTrigger.GetBehaviourForObjectWithID (entity.tag);

			switch (tbehaviour) {
			case Trigger2D.TriggerBehaviour.Destroy:
				TriggerBehaviourDestroy (entity);
				break;
			case Trigger2D.TriggerBehaviour.Teleport:
				TriggerBehaviourTeleport (entity, collidable);
				break;
			default:
				//Do nothing
				break;
			}

			collidable.isTriggerNew = false;
		}
	}

	void TriggerBehaviourDestroy(GameObject entity) {
		entity.AddComponent<Destroyed>();
	}

	void TriggerBehaviourTeleport(GameObject entity, Collidable2D collidable) {

		Trigger2D trigger = collidable.currentTrigger;

		//Transform vars
		float teleportDestinationX = entity.transform.position.x;
		float teleportDestinationY = entity.transform.position.y;
		int directionX = trigger.transform.position.x.CompareTo (trigger.teleportDestination.x);
		int directionY = trigger.transform.position.y.CompareTo (trigger.teleportDestination.y);

		//Grapic vars
		bool doTeleportGraphic = trigger.TeleportEffect != null;
		Vector2 teleportOutGraphicPoint = new Vector2(teleportDestinationX, teleportDestinationY);
		GameObject currentTeleportGraphic;
		bool teleportGraphicFlipX = false;
		bool teleportGraphicFlipY = false;

		//Determine Graphics and Destination from TeleportBehaviour
		switch (trigger.teleportBehaviour) {
		case Trigger2D.TeleportBehaviour.TeleportX:
			teleportDestinationX = trigger.teleportDestination.x;
			teleportOutGraphicPoint.x = trigger.transform.position.x + (Mathf.Abs (trigger.transform.position.x) * -0.16f * directionX);
			teleportGraphicFlipY = true;
			break;
		case Trigger2D.TeleportBehaviour.TeleportY:
			teleportDestinationY = trigger.teleportDestination.y;
			teleportOutGraphicPoint.y = trigger.transform.position.y + (Mathf.Abs (trigger.transform.position.y) * -0.16f * directionY);
			teleportGraphicFlipX = true;
			break;
		case Trigger2D.TeleportBehaviour.TeleportXY:
			teleportDestinationX = trigger.teleportDestination.x;
			teleportDestinationY = trigger.teleportDestination.y;
			teleportOutGraphicPoint.x = trigger.transform.position.x + (Mathf.Abs (trigger.transform.position.x) * -0.16f * directionX);
			teleportOutGraphicPoint.y = trigger.transform.position.y + (Mathf.Abs (trigger.transform.position.y) * -0.16f * directionY);
			teleportGraphicFlipX = true;
			teleportGraphicFlipY = true;
			break;
		default:
			return;
		}

		//Draw Pre-Graphic
		if (doTeleportGraphic) {
			currentTeleportGraphic = GameObject.Instantiate (trigger.TeleportEffect, 
				new Vector3 (teleportOutGraphicPoint.x,
					teleportOutGraphicPoint.y,
					entity.transform.position.z),
				trigger.TeleportEffect.transform.rotation) as GameObject;
			if (teleportGraphicFlipY) { currentTeleportGraphic.GetComponent<SpriteRenderer> ().flipY = directionX > 0; }
			if (teleportGraphicFlipX) { currentTeleportGraphic.GetComponent<SpriteRenderer> ().flipX = directionY > 0; };

		}

		//Teleport entity
		entity.transform.position = (new Vector3(
			teleportDestinationX,
			teleportDestinationY,
			entity.transform.position.z
		));

		//Draw Post-Graphic
		if (doTeleportGraphic) {
			currentTeleportGraphic = GameObject.Instantiate (trigger.TeleportEffect, 
				new Vector3 (teleportDestinationX,
					teleportDestinationY,
					entity.transform.position.z),
				trigger.TeleportEffect.transform.rotation) as GameObject;
			if (teleportGraphicFlipY) { currentTeleportGraphic.GetComponent<SpriteRenderer> ().flipY = directionX < 0; }
			if (teleportGraphicFlipX) { currentTeleportGraphic.GetComponent<SpriteRenderer> ().flipX = directionY < 0; };
			
			
		}
	}
}
