using UnityEngine;
using System.Collections;

//The Gun Component
public class Gun : JoshECSComponent {

	public Mobile2D proj; //Projectile that the gun fires.
	public RenewableResource temperature;
	public float heatGenerated; //Heat generated per shot
	public bool triggered; //Is the gun in the process of firing

	public float RPS; //Rounds per second
	public float TimeOfLastShot;
	public float projectileSpeed;

	public override void Initialise() {
		base.Initialise();
		TimeOfLastShot = Time.time;
	}

	public bool canFire() {
		return (Time.time - TimeOfLastShot > 1 / RPS && temperature.current < temperature.maximum);
	}

}
