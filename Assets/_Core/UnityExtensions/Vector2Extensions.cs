using System.ComponentModel;
using UnityEngine;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class Vector2Extensions {

	public static Vector3 ToVector3WithX(this Vector2 vector, float x) => new(x, vector.x, vector.y);
	public static Vector3 ToVector3WithY(this Vector2 vector, float y) => new(vector.x, y, vector.y);
	public static Vector3 ToVector3WithZ(this Vector2 vector, float z) => new(vector.x, vector.y, z);

	public static Vector3 ToVector3(this Vector2 vector, float z = 0f) => new(vector.x, vector.y, z);

}