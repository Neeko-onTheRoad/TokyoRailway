using System;
using System.Collections.Generic;

public static partial class Validation /* Compare */ {

	//======================================================================| Value, Value

	public static ValidationResult IsEqualTo<TEquatable>(
		TEquatable value,
		TEquatable target,
		string nameOfValue = null,
		string nameOfTarget = null
	) where TEquatable : IEquatable<TEquatable> =>
		Validate<InvalidOperationException>(
			target.Equals(value),
			() => new(
				"[mentionValue] must be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsNotEqualTo<TEquatable>(
		TEquatable value,
		TEquatable target,
		string nameOfValue = null,
		string nameOfTarget = null
	) where TEquatable : IEquatable<TEquatable> =>
		Validate<InvalidOperationException>(
			!target.Equals(value),
			() => new(
				"[mentionValue] must not be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsBiggerThan<TComparable>(
		TComparable value,
		TComparable target,
		string nameOfValue = null,
		string nameOfTarget = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			target.CompareTo(value) < 0,
			() => new(
				"[mentionValue] must be bigger than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsBiggerThanOrEqualTo<TComparable>(
		TComparable value,
		TComparable target,
		string nameOfValue = null,
		string nameOfTarget = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			target.CompareTo(value) <= 0,
			() => new(
				"[mentionValue] must be bigger than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsSmallerThan<TComparable>(
		TComparable value,
		TComparable target,
		string nameOfValue = null,
		string nameOfTarget = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			target.CompareTo(value) > 0,
			() => new(
				"[mentionValue] must be smaller than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsSmallerThanOrEqualTo<TComparable>(
		TComparable value,
		TComparable target,
		string nameOfValue = null,
		string nameOfTarget = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			target.CompareTo(value) >= 0,
			() => new(
				"[mentionValue] must be smaller than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual target value", target)
			)
		);

	//======================================================================| Value, Collection

	public static ValidationResult IsEqualTo<T>(
		int value,
		IReadOnlyCollection<T> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count == value,
			() => new(
				"[mentionValue] must be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual count of collection", target.Count)
			)
		);

	public static ValidationResult IsNotEqualTo<T>(
		int value,
		IReadOnlyCollection<T> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count != value,
			() => new(
				"[mentionValue] must not be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual count of collection", target.Count)
			)
		);

	public static ValidationResult IsBiggerThan<T>(
		int value,
		IReadOnlyCollection<T> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count < value,
			() => new(
				"[mentionValue] must be bigger than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual count of collection", target.Count)
			)
		);

	public static ValidationResult IsBiggerThanOrEqualTo<T>(
		int value,
		IReadOnlyCollection<T> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count <= value,
			() => new(
				"[mentionValue] must be bigger than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual count of collection", target.Count)
			)
		);

	public static ValidationResult IsSmallerThan<T>(
		int value,
		IReadOnlyCollection<T> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count > value,
			() => new(
				"[mentionValue] must be smaller than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual count of collection", target.Count)
			)
		);

	public static ValidationResult IsSmallerThanOrEqualTo<T>(
		int value,
		IReadOnlyCollection<T> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count >= value,
			() => new(
				"[mentionValue] must be smaller than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual value", value)
					.AddInfo("Actual count of collection", target.Count)
			)
		);

	//======================================================================| Collection, Value

	public static ValidationResult IsEqualTo<T>(
		IReadOnlyCollection<T> value,
		int target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target == value.Count,
			() => new(
				"[mentionValue] must be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsNotEqualTo<T>(
		IReadOnlyCollection<T> value,
		int target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target != value.Count,
			() => new(
				"[mentionValue] must not be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsBiggerThan<T>(
		IReadOnlyCollection<T> value,
		int target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target < value.Count,
			() => new(
				"[mentionValue] must be bigger than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsBiggerThanOrEqualTo<T>(
		IReadOnlyCollection<T> value,
		int target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target <= value.Count,
			() => new(
				"[mentionValue] must be bigger than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsSmallerThan<T>(
		IReadOnlyCollection<T> value,
		int target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target > value.Count,
			() => new(
				"[mentionValue] must be smaller than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target value", target)
			)
		);

	public static ValidationResult IsSmallerThanOrEqualTo<T>(
		IReadOnlyCollection<T> value,
		int target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target >= value.Count,
			() => new(
				"[mentionValue] must be smaller than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "target value", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target value", target)
			)
		);

	//======================================================================| Collection, Collection

	public static ValidationResult IsEqualTo<TValue, TTarget>(
		IReadOnlyCollection<TValue> value,
		IReadOnlyCollection<TTarget> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count == value.Count,
			() => new(
				"[mentionValue] must be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target count", target.Count)
			)
		);

	public static ValidationResult IsNotEqualTo<TValue, TTarget>(
		IReadOnlyCollection<TValue> value,
		IReadOnlyCollection<TTarget> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count != value.Count,
			() => new(
				"[mentionValue] must not be equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target count", target.Count)
			)
		);

	public static ValidationResult IsBiggerThan<TValue, TTarget>(
		IReadOnlyCollection<TValue> value,
		IReadOnlyCollection<TTarget> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count < value.Count,
			() => new(
				"[mentionValue] must be bigger than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target count", target.Count)
			)
		);

	public static ValidationResult IsBiggerThanOrEqualTo<TValue, TTarget>(
		IReadOnlyCollection<TValue> value,
		IReadOnlyCollection<TTarget> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count <= value.Count,
			() => new(
				"[mentionValue] must be bigger than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target count", target.Count)
			)
		);

	public static ValidationResult IsSmallerThan<TValue, TTarget>(
		IReadOnlyCollection<TValue> value,
		IReadOnlyCollection<TTarget> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count > value.Count,
			() => new(
				"[mentionValue] must be smaller than [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target count", target.Count)
			)
		);

	public static ValidationResult IsSmallerThanOrEqualTo<TValue, TTarget>(
		IReadOnlyCollection<TValue> value,
		IReadOnlyCollection<TTarget> target,
		string nameOfValue = null,
		string nameOfTarget = null
	) =>
		Validate<InvalidOperationException>(
			target.Count >= value.Count,
			() => new(
				"[mentionValue] must be smaller than or equal to [mentionTarget]."
					.MentionOrPronoun(nameOfValue, "count of collection", "mentionValue")
					.MentionOrPronoun(nameOfTarget, "count of collection", "mentionTarget")
					.AddInfo("Actual count of collection", value.Count)
					.AddInfo("Actual target count", target.Count)
			)
		);

}