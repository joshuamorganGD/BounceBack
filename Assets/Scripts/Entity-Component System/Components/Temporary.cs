using UnityEngine;
using System.Collections;

public class Temporary : JoshECSComponent {

	public float durationInSeconds;
	public float TimeCreated;

	public override void Initialise() {
		TimeCreated = Time.time;
		base.Initialise();
	}	
}
