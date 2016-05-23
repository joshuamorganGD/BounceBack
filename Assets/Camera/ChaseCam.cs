using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class ChaseCam : AbstractTargetFollower {

	float smoothTime = 60f;
	float VelocityY = 0.0f;
	public float minY;
	public float maxY;
	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	protected override void FollowTarget(float deltaTime) {
		if (Target != null) {
			float newY = Mathf.SmoothDamp(Target.transform.position.y, transform.position.y, ref VelocityY, smoothTime);
			transform.position = new Vector3 (transform.position.x, Mathf.Clamp(newY, minY, maxY), transform.position.z);
		}

	}
}
