using System;

public partial class Validation {

	public static bool Validate(Func<bool> criteria, string failureMessage, out InvalidOperationException exception) {

		if (criteria()) {
			exception = new(failureMessage);
			return false;
		}

		exception = default;
		return true;

	}

}