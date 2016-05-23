using UnityEngine;
using System.Collections;

public class DestructibleEngineMobile2DProcessor : JoshECSProcessor<Destructible, Engine, Mobile2D> {

	protected override void Process(GameObject entity, Destructible destructible, Engine engine, Mobile2D mobile) {

		if (destructible.hitPoints.current > 0) {
			TryRegenerateHP (destructible, engine, mobile);
		}
	}

	void TryRegenerateHP(Destructible destructible, Engine engine,  Mobile2D mobile) {

		switch (destructible.HPRegenStyle) {
		case Destructible.HPRegenerationStyle.Kinetic:
			destructible.hitPoints.tryRegenerate(mobile.velocity.magnitude / engine.maxSpeed * destructible.KineticRegenerationFactor);
			break;
		default:
			//Do nothing
			return;
		}
	}
}
