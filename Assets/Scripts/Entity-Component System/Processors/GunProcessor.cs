using UnityEngine;
using System.Collections;

public class GunProcessor : JoshECSProcessor<Gun> {

	protected override void Process(GameObject entity, Gun gun) {

		if (gun.triggered && gun.canFire()) {
			//Existing velocity of gun
			Vector3 gunVelocity = Vector3.zero;
			if (entity.GetComponent<Mobile2D> () != null && entity.GetComponent<Mobile2D>().isActiveAndEnabled) {
				gunVelocity = entity.GetComponent<Mobile2D> ().velocity;
			}

			//Shoot
			gun.TimeOfLastShot = Time.time;
			gun.temperature.gain(gun.heatGenerated);
			GameObject proj = GameObject.Instantiate(gun.proj.gameObject, entity.transform.position + entity.transform.up*2, entity.transform.rotation) as GameObject;
			proj.GetComponent<Mobile2D> ().velocity = entity.transform.up * (gun.projectileSpeed + Mathf.Max(0,Vector3.Dot(entity.transform.up, gunVelocity)));
		}

		gun.temperature.tryRegenerate();
	}
}
