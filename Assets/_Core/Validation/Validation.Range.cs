using System;

public static partial class Validation {

	public static class Range {

		public static ValidationResult IsInRangeInclusive(int value, int from, int to, string nameOfValue = null) =>
			Validate<InvalidOperationException>(
				from <= value && value <= to,
				() => new($"[mention] must be in inclusive range [{from}, {to}]."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
				)
			);

	}

}