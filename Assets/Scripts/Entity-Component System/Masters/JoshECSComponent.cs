using UnityEngine;
using System.Collections;

public abstract class JoshECSComponent : MonoBehaviour {

	protected static JoshECSCoordinator ecsCoordinator;

	public void OnEnable() {
		Initialise();
		RegisterComponent();
	}

	public void OnDisable() {
		UnregisterComponent();
	}



	public virtual void Initialise() {
		if (ecsCoordinator == null) {
			ecsCoordinator = GameObject.Find ("ECS Coordinator").GetComponent<JoshECSCoordinator>();
		}
	}

	public virtual void RegisterComponent() {
		ecsCoordinator.RegisterComponent (this);
	
	}

	public virtual void UnregisterComponent() {
		ecsCoordinator.UnregisterComponent(this);
	}
}
