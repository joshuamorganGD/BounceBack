using UnityEngine;
using System.Collections;

public class EmergencyBounceMobile2DProcessor : JoshECSProcessor<EmergencyBounce, Mobile2D> {

	bool hasFired;

	protected override void Process(GameObject entity, EmergencyBounce bounce, Mobile2D mobile) {

		switch (bounce.currentStage) {
		case EmergencyBounce.Stage.Idle:
			Check (entity, bounce);
			break;
		case EmergencyBounce.Stage.Turning:
			Turn (entity, bounce, mobile);
			break;
		case EmergencyBounce.Stage.Braking:
			Brake (bounce, mobile);
			break;
		case EmergencyBounce.Stage.Firing:
			Fire (entity, bounce, mobile);
			break;
		}
	}

	void Check(GameObject entity, EmergencyBounce bounce) {

		if (entity.transform.position.y <= bounce.activationHeight) {
			bounce.currentStage = EmergencyBounce.Stage.Turning;
		}
	}

	void Turn(GameObject entity, EmergencyBounce bounce, Mobile2D mobile) {


		//Turn
		entity.transform.up = Vector3.RotateTowards(entity.transform.up, Vector3.up, 15f * Time.deltaTime, 0.0f);

		//Change Stage
		if (entity.transform.up == Vector3.up) {
			bounce.currentStage = EmergencyBounce.Stage.Braking;
		}
	}

	void Brake(EmergencyBounce bounce, Mobile2D mobile) {


		//Kill Velocity
		mobile.velocity = Vector3.MoveTowards(mobile.velocity, Vector3.zero, 75f * Time.deltaTime);

		if (mobile.velocity == Vector3.zero) {
			bounce.currentStage = EmergencyBounce.Stage.Firing;
		}
	}

	void Fire(GameObject entity, EmergencyBounce bounce, Mobile2D mobile) {

		if (!hasFired) {
			mobile.velocity = new Vector3(0, mobile.TerminalVelocity * 2.5f, 0);
			hasFired = true;

		}

		if (mobile.velocity.y <= 0) {
			hasFired = false;
			bounce.currentStage = EmergencyBounce.Stage.Idle;
		}
	}
}
