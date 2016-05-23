using UnityEngine;
using System.Collections;

public class GunPlayerInputProcessor: JoshECSProcessor<Gun, PlayerInput> {

	protected override void Process(GameObject entity, Gun gun, PlayerInput input) {

		gun.triggered = input.fire;
	}
}
