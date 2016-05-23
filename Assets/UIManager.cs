using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public UIMeter gunTemperature;
	public UIMeter boostFuel;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			Gun g = player.GetComponent<Gun> ();
			gunTemperature.percentageToEnable = g.temperature.current / g.temperature.maximum;

			Engine e = player.GetComponent<Engine> ();
			boostFuel.percentageToEnable = e.fuel.current / e.fuel.maximum;
		}
	}
}
