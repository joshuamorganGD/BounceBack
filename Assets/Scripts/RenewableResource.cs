using UnityEngine;
using System.Collections;

//Renewable Resource is a measurable value that increases and decreases in magnitude.
[System.Serializable]
public class RenewableResource {

	public float maximum;
	public float current;

	[Range(0,1)]
	public float baseRegenerationRate;
	public float dynamicRegenerationModifier;

	public bool oppositeScale; //True if scale is 0-Maximum instead of Maximum-0

	float timeOfLastDepletion;
	float regenerationDelay = 1f;

	public void gain(float gained) {
		current += Mathf.Min (gained, maximum - current);

		if (oppositeScale) {
			timeOfLastDepletion = Time.time;
		}
	}

	public void lose(float lost) {
		current -= Mathf.Min (lost, current);

		if (!oppositeScale) {
			timeOfLastDepletion = Time.time;
		}

	}

	bool canRegenerate() {
		return Time.time - timeOfLastDepletion > regenerationDelay && baseRegenerationRate * dynamicRegenerationModifier != 0;
	}

	void regenerate() {

		if (!oppositeScale) {
			if (current < maximum) {
				gain (baseRegenerationRate * dynamicRegenerationModifier * maximum * Time.deltaTime);
			}
		} 
		else {
			if (current > 0) {
				lose (baseRegenerationRate * dynamicRegenerationModifier * maximum * Time.deltaTime);
			}	
		}
	}

	public void tryRegenerate() {
		dynamicRegenerationModifier = 1;
		if (canRegenerate()) {
			regenerate();
		}
	}

	public void tryRegenerate(float dynamicRegenerationMod) {

		dynamicRegenerationModifier = dynamicRegenerationMod;
		if (canRegenerate()) {
			regenerate();
		}
	}
}
