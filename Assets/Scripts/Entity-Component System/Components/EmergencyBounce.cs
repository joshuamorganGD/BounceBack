using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Mobile2D))]
public class EmergencyBounce : JoshECSComponent {

	public enum Stage {
		Idle,
		Turning,
		Braking,
		Firing,
	}

	public Stage currentStage;
	public float activationHeight;
	public float deactivationHeight;
}
