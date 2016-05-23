using UnityEngine;
using System.Collections;

public class Destroyed : JoshECSComponent {

	//No Data
	public void Destroy() {
		Destroy (gameObject);
	}

	public void MarkForDeletion() {
		ecsCoordinator.MarkForDeletion(gameObject);
	}
}
