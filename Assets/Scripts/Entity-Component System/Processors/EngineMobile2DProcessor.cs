using UnityEngine;
using System.Collections;

public class EngineMobile2DProcessor : JoshECSProcessor<Engine, Mobile2D> {

	protected override void Initialise(GameObject entity, Engine engine, Mobile2D mobile) {
		engine.fuelConsumptionPerSecond = 20;
		engine.KineticRegenerationFactor = 1.5f;
	}

	protected override void Process(GameObject entity, Engine engine, Mobile2D mobile) {

		//Input -> Mobile

		//Change Velocity
		ChangeVelocity(entity, engine, mobile);

		//Rotation
		mobile.rotation = engine.rudderStrength * engine.turnSpeed;

		TryRegenerateFuel (engine, mobile);
	}

	void ChangeVelocity(GameObject entity, Engine engine, Mobile2D mobile) {

		if (engine.throttle > 0 && Vector3.Dot (entity.transform.up, mobile.velocity) < engine.maxSpeed && engine.fuel.current > 0) {

			mobile.velocity += entity.transform.up * engine.throttle * engine.acceleration * Time.deltaTime;
			engine.fuel.lose (engine.fuelConsumptionPerSecond * Time.deltaTime);
		} 
		else if (engine.throttle < 0) {
			//Brakes
		}
	}

	void TryRegenerateFuel(Engine engine, Mobile2D mobile) {
		switch (engine.fuelRegenStyle) {
		case Engine.FuelRegenerationStyle.Kinetic:
			engine.fuel.tryRegenerate(mobile.velocity.magnitude / engine.maxSpeed * engine.KineticRegenerationFactor);
			break;
		case Engine.FuelRegenerationStyle.Static:
			engine.fuel.tryRegenerate();
			break;
		default:
			engine.fuel.tryRegenerate();
			break;
		}
	}
}
