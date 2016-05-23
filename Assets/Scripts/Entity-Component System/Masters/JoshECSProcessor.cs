using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public abstract class JoshECSProcessor {

	public System.Type[] RequiredTypes;

	protected JoshECSProcessor() {
		RequiredTypes = GetType().BaseType.GetGenericArguments();
	}

	public bool isInterestedIn (GameObject entity) {
		if (entity.Equals(null)) { return false; }

		foreach (System.Type type in RequiredTypes) {
			var possibleComponent = (MonoBehaviour)entity.GetComponent(type);
			if (possibleComponent == null) {
				return false;
			}
			if (possibleComponent.enabled == false) {
				return false;
			}
		}

		return true;
	}

	public abstract void InitialiseAll (List<EntityAndComponents> entities);
	public abstract void ProcessAll (List<EntityAndComponents> entities);
}

public abstract class JoshECSProcessor<T1> : JoshECSProcessor where T1 : JoshECSComponent {

	protected virtual void Initialise (GameObject entity, T1 Component1){}
	protected virtual void Process (GameObject entity, T1 Component1){}

	public override void InitialiseAll (List<EntityAndComponents> EntitiesAndComponents)
	{
		foreach (EntityAndComponents entity in EntitiesAndComponents) {
			Initialise(entity.entity, (T1)entity.components.Find(c => c.GetType().Equals(typeof(T1))));
		}
	}

	public override void ProcessAll (List<EntityAndComponents> EntitiesAndComponents)
	{
		foreach (EntityAndComponents entity in EntitiesAndComponents) {
			Process(entity.entity, (T1)entity.components.Find(c => c.GetType().Equals(typeof(T1))));
		}
	}

}

public abstract class JoshECSProcessor<T1, T2> : JoshECSProcessor where T1 : JoshECSComponent where T2 : JoshECSComponent {


	protected virtual void Initialise (GameObject entity, T1 Component1, T2 Component2){}
	protected virtual void Process (GameObject entity, T1 Component1, T2 Component2){}

	public override void InitialiseAll (List<EntityAndComponents> EntitiesAndComponents)
	{
		foreach (EntityAndComponents ec in EntitiesAndComponents) {
			Initialise(ec.entity, 
				(T1)ec.components.Find(c => c.GetType().Equals(typeof(T1))),
				(T2)ec.components.Find(c => c.GetType().Equals(typeof(T2)))
			);
		}
	}

	public override void ProcessAll (List<EntityAndComponents> EntitiesAndComponents)
	{
		foreach (EntityAndComponents ec in EntitiesAndComponents) {
			Process(ec.entity, 
				(T1)ec.components.Find(c => c.GetType().Equals(typeof(T1))),
				(T2)ec.components.Find(c => c.GetType().Equals(typeof(T2)))
			);
		}
	}
}

public abstract class JoshECSProcessor<T1, T2, T3> : JoshECSProcessor where T1 : JoshECSComponent where T2 : JoshECSComponent
	where T3 : JoshECSComponent {

	protected virtual void Initialise (GameObject entity, T1 Component1, T2 Component2, T3 Component3){}
	protected virtual void Process (GameObject entity, T1 Component1, T2 Component2, T3 Component3){}

	public override void InitialiseAll (List<EntityAndComponents> EntitiesAndComponents)
	{
		foreach (EntityAndComponents ec in EntitiesAndComponents) {
			Initialise(ec.entity, 
				(T1)ec.components.Find(c => c.GetType().Equals(typeof(T1))),
				(T2)ec.components.Find(c => c.GetType().Equals(typeof(T2))),
				(T3)ec.components.Find(c => c.GetType().Equals(typeof(T3)))
			);
		}
	}

	public override void ProcessAll (List<EntityAndComponents> EntitiesAndComponents)
	{
		foreach (EntityAndComponents ec in EntitiesAndComponents) {
			Process(ec.entity, 
				(T1)ec.components.Find(c => c.GetType().Equals(typeof(T1))),
				(T2)ec.components.Find(c => c.GetType().Equals(typeof(T2))),
				(T3)ec.components.Find(c => c.GetType().Equals(typeof(T3)))
			);
		}
	}
}

