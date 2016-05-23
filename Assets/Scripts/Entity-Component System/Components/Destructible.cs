using UnityEngine;
using System.Collections;

public class Destructible : JoshECSComponent {

	public RenewableResource hitPoints;

	public enum HPRegenerationStyle {
		Static,
		Kinetic,
	}

	public HPRegenerationStyle HPRegenStyle;
	public float KineticRegenerationFactor;

	public Mobile2D[] debris;

	public GameObject debrisEffect;
}
