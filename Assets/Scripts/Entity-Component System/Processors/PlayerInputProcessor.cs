using UnityEngine;
using System.Collections;

public class PlayerInputProcessor : JoshECSProcessor<PlayerInput> {

	protected override void Process(GameObject entity, PlayerInput input) {

		input.throttle = -Input.GetAxis ("LR Trigger");
		input.rotation = -Input.GetAxis ("Horizontal");
		input.fire = Input.GetButton("Fire1");
	}
}
