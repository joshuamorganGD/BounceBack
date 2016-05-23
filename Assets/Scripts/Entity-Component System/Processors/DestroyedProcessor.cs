using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DestroyedProcessor : JoshECSProcessor<Destroyed> {

	protected override void Process(GameObject entity, Destroyed destroyed) {

		//Unregister Components
		List<JoshECSComponent> componentsToDisable = entity.gameObject.GetComponents<JoshECSComponent>().Where(c => c.isActiveAndEnabled).ToList();
		foreach (JoshECSComponent component in componentsToDisable) {
			component.UnregisterComponent();
		}

		destroyed.MarkForDeletion();
	}
}
