using UnityEngine;

public static class Geometry {

	public static bool IsFrontSide(Vector2 a, Vector2 b, Vector2 c) => 
		Vector2.Dot(a - b, c - b) >= 0f;

	public static bool IsBackSide(Vector2 a, Vector2 b, Vector2 c) =>
		Vector2.Dot(a - b, c - b) <= 0f;

}