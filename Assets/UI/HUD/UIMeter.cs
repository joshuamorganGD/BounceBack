using UnityEngine;
using System.Collections;

public class UIMeter : MonoBehaviour {

	public GameObject[] notches;

	public float percentageToEnable;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < notches.Length; i++) {

			if (((float)i / (float)notches.Length) <= percentageToEnable) {
				notches [i].SetActive (true);
			} 
			else {
				notches [i].SetActive (false);
			}
		}
	}
}
