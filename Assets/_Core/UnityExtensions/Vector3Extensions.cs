using UnityEngine;

public static class Vector3Extensions {

	public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);
	public static Vector3 WithY(this Vector3 vector, float y) => new(vector.x, y, vector.z);
	public static Vector3 WithZ(this Vector3 vector, float z) => new(vector.x, vector.y, z);

	public static Vector2 WithoutX(this Vector3 vector) => new(vector.y, vector.z);
	public static Vector2 WithoutY(this Vector3 vector) => new(vector.x, vector.z);
	public static Vector2 WithoutZ(this Vector3 vector) => new(vector.x, vector.z);

	public static Vector3 FlipWithoutX(this Vector3 vector) => new(vector.x, -vector.y, -vector.z);
	public static Vector3 FlipWithoutY(this Vector3 vector) => new(-vector.x, vector.y, -vector.z);
	public static Vector3 FlipWithoutZ(this Vector3 vector) => new(-vector.x, -vector.y, vector.z);

}