using UnityEngine;
using System.Collections;

public class Mobile2DProcessor : JoshECSProcessor<Mobile2D> {

	protected override void Process(GameObject entity, Mobile2D component) {

		//Linear Drag
		component.velocity.x = Mathf.MoveTowards(component.velocity.x, 0, component.linearDrag * Time.deltaTime);
		component.velocity.y = Mathf.MoveTowards(component.velocity.y, 0, component.linearDrag * Time.deltaTime);
		component.velocity.z = Mathf.MoveTowards(component.velocity.z, 0, component.linearDrag * Time.deltaTime);

		//Angular Drag

		//Gravity
		if (component.velocity.y > -component.TerminalVelocity) {
			component.velocity += Vector3.down * component.gravityScale * 9.8f * Time.deltaTime;
		}




		entity.transform.Translate (new Vector3(component.velocity.x, component.velocity.y, 0) * Time.deltaTime, Space.World);
		entity.transform.Rotate (Vector3.forward * component.rotation * Time.deltaTime);
	}
}
