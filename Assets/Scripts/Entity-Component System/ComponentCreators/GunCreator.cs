using UnityEngine;
using System.Collections;

public static class GunCreator {

	public enum RPS {
		Slow,
		Average,
		Fast,
		VeryFast,
	}

	public enum Damage {
		Low,
		Average,
		High,
		VeryHigh,
	}

	public static void AddGun(GameObject entity, RPS rps, Damage dam) {
		Gun g = entity.AddComponent<Gun>();
		AdjustStats (g, rps, dam);
	}

	private static float GetRPSValue(RPS rps) {
		switch (rps) {
		case RPS.Slow:
			return 0;
		case RPS.Average:
			return 0;
		case RPS.Fast:
			return 0;
		case RPS.VeryFast:
			return 0;
		default:
			return 0;
		}
	}

	private static float GetDamageValue(Damage dam) {
		switch (dam) {
		case Damage.Low:
			return 0;
		case Damage.Average:
			return 0;
		case Damage.High:
			return 0;
		case Damage.VeryHigh:
			return 0;
		default:
			return 0;
		}
	}

	private static void AdjustStats(Gun g, RPS rps, Damage dam) {
		g.RPS = GetRPSValue (rps);
		g.proj.GetComponent<Collidable2D> ().damageDone = GetDamageValue(dam);
	}



}
