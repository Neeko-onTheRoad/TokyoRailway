using System;

public static partial class Searching /*Function*/ {

	public static float TernarySearch(

		Func<float, float> func,
		float startBound,
		float endBound,
		float count = 32
		
	) {

		float midRight = 0f;
		float midLeft = 0f;

		for (int i = 0; i < count; i++) {

			midLeft = (2f * startBound + endBound) / 3f;
			midRight = (startBound + 2f * endBound) / 3f;

			var midLeftValue = func(midLeft);
			var midRightValue = func(midRight);

			if (midLeftValue > midRightValue) startBound = midLeft;
			else endBound = midRight;

		}
		
		return (midRight + midLeft) / 2f;

	}

}