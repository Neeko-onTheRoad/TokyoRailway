using System.ComponentModel;
using UnityEngine;
using UnityEngine.Splines;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class SplineExtensions {

	public static float GetLengthBetween(this Spline spline, int from, int to) {

		Validation.ThrowIfInvalid(
			Validation.IsInRange(from, spline, null, nameof(from)),
			Validation.IsInRange(to, spline, null, nameof(to)),
			Validation.IsBiggerThan(to, from, nameof(to), nameof(from)) 
		);
		
		float length = 0f;

		for (int i = from; i < to; i++) {
			length += spline.GetCurveLength(i);
		}

		return length;

	}
	
	public static BezierKnot GetKnot(this SplineContainer container, SplineKnotIndex index) =>
		container[index.Spline][index.Knot];

	public static Vector3 GetTangent(this SplineContainer container, SplineKnotIndex index) {

		var spline = container.Splines[index.Spline];
		var knot = spline[index.Knot];

		var tangent = knot.Rotation.ToQuaternion() * knot.TangentOut.ToVector3();

		return container.transform.TransformDirection(tangent).normalized;

	}

	public static SplineKnotIndex WithSpline(this SplineKnotIndex index, int spline) => new(spline, index.Knot);
	public static SplineKnotIndex WithKnot(this SplineKnotIndex index, int knot) => new(index.Spline, knot);

}