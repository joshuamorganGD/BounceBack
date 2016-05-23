using UnityEngine;
using System.Collections;

public class TemporaryProcessor : JoshECSProcessor <Temporary> {

	protected override void Process(GameObject entity, Temporary component) {
		if (Time.time - component.TimeCreated > component.durationInSeconds) {

			if (component.gameObject.GetComponent<Destroyed> () == null) {
				component.gameObject.AddComponent<Destroyed>();
			}
		}

		//Debug.Log (((Time.time - component.TimeCreated) / component.durationInSeconds) * 255);

		if (entity.GetComponent<SpriteRenderer> () != null) {
			entity.GetComponent<SpriteRenderer> ().color = new Vector4(
				255,
				255,
				255,
				Mathf.Clamp((1 - (Time.time - component.TimeCreated) / component.durationInSeconds), 0, 255f));
		}
	}
}
