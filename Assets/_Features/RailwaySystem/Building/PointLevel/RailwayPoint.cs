using UnityEngine;

public record RailwayPoint(

	Vector3 Position,
	Vector3 Tangent,
	Vector3 Normal

) {

	public static RailwayPoint Lerp(RailwayPoint a, RailwayPoint b, float t) {

		var tangent = Vector3.Lerp(a.Tangent, b.Tangent, t);
		var normal = Vector3.Lerp(a.Normal, b.Normal, t);

		Vector3.OrthoNormalize(ref tangent, ref normal);

		return new(
			Vector3.Lerp(a.Position, b.Position, t),
			tangent,
			normal
		);

	}

}