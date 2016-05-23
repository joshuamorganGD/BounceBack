using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EntityAndComponents
{
	public GameObject entity;
	public List<JoshECSComponent> components = new List<JoshECSComponent>();
}

public abstract class JoshECSCoordinator : MonoBehaviour {

	public Dictionary<JoshECSProcessor, List<EntityAndComponents>> processorsAndECs = new Dictionary<JoshECSProcessor, List<EntityAndComponents>>();
	public List<JoshECSProcessor> processors = new List<JoshECSProcessor>();

	Queue registerQueue = new Queue();
	Queue unregisterQueue = new Queue();
	Queue deleteQueue = new Queue();



	protected virtual void Awake() {
		
	}

	protected void Start() {
		ActOnQueueComponent (registerQueue, Register);
		Initialise();
	}

	protected void Update() {
		ActOnQueueComponent (unregisterQueue, Unregister);
		ActOnQueueEntity (deleteQueue, Destroy);
		ActOnQueueComponent (registerQueue, Register);
		RunProcessors();
	}

	protected void Initialise() {
		foreach (JoshECSProcessor processor in processorsAndECs.Keys) {
			processor.InitialiseAll(processorsAndECs[processor]);
		}
	}

	public void RegisterComponent(JoshECSComponent component) {
		registerQueue.Enqueue (component);
	}

	public void UnregisterComponent(JoshECSComponent component) {

		if (!component.isActiveAndEnabled) {
			return;
		}

		unregisterQueue.Enqueue (component);
	}

	protected void ActOnQueueEntity (Queue q, System.Action<GameObject> function) {
		while (q.Count > 0) {
			function.Invoke ((GameObject)q.Dequeue());
		}
	}

	protected void ActOnQueueComponent (Queue q, System.Action<JoshECSComponent> function) {
		while (q.Count > 0) {
			function.Invoke ((JoshECSComponent)q.Dequeue());
		}
	}

	void Register(JoshECSComponent component) {

		//Cache component's entity
		GameObject entity = component.gameObject;

		//For each processor that deals with same-typed components and is interested in the entity
		foreach (JoshECSProcessor processor in processorsAndECs.Keys.Where(processor => processor.RequiredTypes.Contains(component.GetType()) && processor.isInterestedIn(entity))) {
				
			//Get EntityAndComponent link
			EntityAndComponents componentEntity = processorsAndECs[processor].FirstOrDefault(e => e.entity == entity);
			if (componentEntity == null) {
				componentEntity = new EntityAndComponents { entity = entity };
				processorsAndECs [processor].Add (componentEntity);
			}

			//If a Component of the Same Type is already registered, do not register this component
			if (componentEntity.components.Any(c => c.GetType() == component.GetType())) {
				return;
			}

			//Add Component
			componentEntity.components.Add (component);

			//Add any missing components that are required for this processor
			if (!processor.RequiredTypes.All(t => componentEntity.components.Exists(c => c.GetType().Equals(t)))) {

				List<JoshECSComponent> MissingComponents = entity.GetComponents<JoshECSComponent>().Where (c => !componentEntity.components.Contains (c) && processor.RequiredTypes.Contains (c.GetType ())).ToList();
				componentEntity.components.AddRange(MissingComponents);
			}
		}
	}

	void Unregister(JoshECSComponent component) {

		GameObject entity = component.gameObject;

		foreach (JoshECSProcessor processor in processorsAndECs.Keys.Where(processor => processor.RequiredTypes.Contains(component.GetType()) && entity != null)) {
			EntityAndComponents ec = processorsAndECs[processor].Find(e => e.entity == entity);
			//Debug.Log (ec.entity);
			processorsAndECs [processor].Remove (ec);

		}

		component.enabled = false;
	}

	public void MarkForDeletion(GameObject entity) {
		deleteQueue.Enqueue (entity);
	}

	protected void RunProcessors() {

		foreach (JoshECSProcessor processor in processorsAndECs.Keys) {
			processor.ProcessAll(processorsAndECs[processor]);
		}
	}
}
