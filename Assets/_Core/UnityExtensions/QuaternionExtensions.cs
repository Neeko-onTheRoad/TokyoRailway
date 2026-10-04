using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class QuaternionExtensions {

	public static Quaternion ToQuaternion(this quaternion quaternion) => new(
		quaternion.value.x,
		quaternion.value.y,
		quaternion.value.z,
		quaternion.value.w
	);

}