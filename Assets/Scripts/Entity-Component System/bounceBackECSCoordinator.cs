using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class bounceBackECSCoordinator : JoshECSCoordinator {

	protected override void Awake() {

		//Add in required Processors.
		processorsAndECs.Add (new PlayerInputProcessor(), new List<EntityAndComponents> ());
		processorsAndECs.Add (new EnginePlayerInputProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new EngineMobile2DProcessor(), new List<EntityAndComponents> ());
		processorsAndECs.Add (new Mobile2DProcessor(), new List<EntityAndComponents> ());
		processorsAndECs.Add (new EmergencyBounceMobile2DProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new GunProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new GunPlayerInputProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new DestructibleProcessor(), new List<EntityAndComponents> ());
		processorsAndECs.Add (new DestructibleEngineMobile2DProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new Collidable2DProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new Collidable2DMobile2DProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new DestructibleCollidable2DProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new TemporaryProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new DestroyedProcessor (), new List<EntityAndComponents> ());
		processorsAndECs.Add (new DestructibleDestroyedProcessor (), new List<EntityAndComponents> ());

		//Debug.Log (new DestructibleProcessor().isInterestedIn(GameObject.Find("Player")) && new DestructibleProcessor().RequiredTypes.Contains(typeof(Destructible)));
	}
}
