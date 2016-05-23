using UnityEngine;
using System.Collections;

public static class EngineCreator {

	public enum Acceleration {
		Slow,
		Average,
		Fast,
		VeryFast
	}

	public enum MaxSpeed {
		Slow,
		Average,
		Fast,
		VeryFast
	}

	public enum TurnSpeed {
		Slow,
		Average,
		Fast,
		VeryFast
	}

	private static float GetAccelerationValue(Acceleration acceleration) {
		switch (acceleration) {
		case Acceleration.Slow:
			return 0;
		case Acceleration.Average:
			return 0;
		case Acceleration.Fast:
			return 0;
		case Acceleration.VeryFast:
			return 0;
		default:
			return 0;
		}
	}

	private static float GetMaxSpeedValue(MaxSpeed max) {
		switch (max) {
		case MaxSpeed.Slow:
			return 0;
		case MaxSpeed.Average:
			return 0;
		case MaxSpeed.Fast:
			return 0;
		case MaxSpeed.VeryFast:
			return 0;
		default:
			return 0;
		}
	}

	private static float GetTurnSpeedValue(TurnSpeed turn) {
		switch (turn) {
		case TurnSpeed.Slow:
			return 0;
		case TurnSpeed.Average:
			return 0;
		case TurnSpeed.Fast:
			return 0;
		case TurnSpeed.VeryFast:
			return 0;
		default:
			return 0;
		}
	}

	public static void AddEngine(GameObject entity, Acceleration acceleration, MaxSpeed max, TurnSpeed turn, Engine.FuelRegenerationStyle fuelRegenerationStyle) {
		Engine e = entity.AddComponent<Engine>();
		AdjustStats (e, acceleration, max, turn, fuelRegenerationStyle);
	}

	private static void AdjustStats(Engine e, Acceleration acceleration, MaxSpeed max, TurnSpeed turn, Engine.FuelRegenerationStyle fuelRegenerationStyle) {
		e.acceleration = GetAccelerationValue (acceleration);
		e.maxSpeed = GetMaxSpeedValue(max);
		e.turnSpeed = GetTurnSpeedValue(turn);
		e.fuelRegenStyle = fuelRegenerationStyle;
	}

	static void foo() {
		GameObject g = new GameObject ();
		AddEngine (g, EngineCreator.Acceleration.Fast, EngineCreator.MaxSpeed.Fast, EngineCreator.TurnSpeed.Fast, Engine.FuelRegenerationStyle.Kinetic);
	}
}
