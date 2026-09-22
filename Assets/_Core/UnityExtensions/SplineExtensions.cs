using UnityEngine.Splines;

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
	
}