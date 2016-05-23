using UnityEngine;
using System.Collections.Generic;

public class Trigger2D : JoshECSComponent {

	public enum TriggerBehaviour {

		DoNothing,
		Destroy,
		Teleport
	}

	public enum TeleportBehaviour {
		TeleportX,
		TeleportY,
		TeleportXY,
	}

	public string[] ids;
	public TriggerBehaviour[] behaviours;

	public TriggerBehaviour GetBehaviourForObjectWithID(string id) {

		TriggerBehaviour toReturn = TriggerBehaviour.DoNothing;

		if (ids.Length != behaviours.Length) {
			return toReturn;
		}

		for (int i = 0; i < ids.Length; i++) {
			if (ids [i] == id) {
				toReturn = behaviours [i];
			}
		}

		return toReturn;
	}

	public TeleportBehaviour teleportBehaviour;
	public Vector2 teleportDestination;
	public GameObject TeleportEffect;


}
