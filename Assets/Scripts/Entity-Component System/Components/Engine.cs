using UnityEngine;
using System.Collections;

//The Engine Component
[RequireComponent(typeof(Mobile2D))]
public class Engine : JoshECSComponent {

	public enum FuelRegenerationStyle {
		Static,
		Kinetic,
	}

	public FuelRegenerationStyle fuelRegenStyle;
	public float KineticRegenerationFactor;

	//Movement/Fuel-Based
	public RenewableResource fuel = new RenewableResource();
	public float acceleration; //Change to velocity per second
	public float fuelConsumptionPerSecond; //Cost to fuel per second of isRunning
	public float turnSpeed; //Speed at which the spaceship rotates.
	public float maxSpeed; //Maximum speed of the spaceship

	public float throttle; //(0-1) Percentage of acceleration applied.
	public float rudderStrength;
}
