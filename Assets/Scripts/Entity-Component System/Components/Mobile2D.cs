using UnityEngine;
using System.Collections;

public class Mobile2D : JoshECSComponent {

	public Vector3 velocity;
	public float linearDrag;
	public float rotation;
	[Range(0,1)]
	public float gravityScale;

	public float TerminalVelocity {
		get { return gravityScale * 9.8f * 2.5f; }
	}

}
