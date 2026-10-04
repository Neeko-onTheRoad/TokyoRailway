using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class Float3Extensions {

	public static Vector3 ToVector3(this float3 float3) => new(float3.x, float3.y, float3.z);

	public static Vector2 ToVector2WithoutX(this float3 float3) => new(float3.y, float3.z);
	public static Vector2 ToVector2WithoutY(this float3 float3) => new(float3.x, float3.z);
	public static Vector2 ToVector2WithoutZ(this float3 float3) => new(float3.x, float3.y);

	public static Vector3 ToVector3WithX(this float3 float3, float x) => new(x, float3.y, float3.z);
	public static Vector3 ToVector3WithY(this float3 float3, float y) => new(float3.x, y, float3.z);
	public static Vector3 ToVector3WithZ(this float3 float3, float z) => new(float3.x, float3.y, z);

}