using UnityEngine;
using System.Collections;

public class DestructibleProcessor : JoshECSProcessor<Destructible> {

	protected override void Process(GameObject entity, Destructible destructible) {
		//Check for Destruction
		if (destructible.hitPoints.current <= 0) {
			if (destructible.gameObject.GetComponent<Destroyed> () == null) {
				destructible.gameObject.AddComponent<Destroyed>();
			}
			return;
		}

		//Regenerate Health
		RegenerateHP(destructible);
	}

	void RegenerateHP(Destructible destructible) {

		switch (destructible.HPRegenStyle) {
		case Destructible.HPRegenerationStyle.Static:
			destructible.hitPoints.tryRegenerate ();
			break;
		default:
			return;
		}
	}
}
