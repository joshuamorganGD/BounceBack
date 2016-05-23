using UnityEngine;
using System.Collections;

public class EnginePlayerInputProcessor : JoshECSProcessor<Engine, PlayerInput> {

	protected override void Process(GameObject entity, Engine engine, PlayerInput input) {
		engine.throttle = input.throttle;
		engine.rudderStrength = input.rotation;
	}
}
