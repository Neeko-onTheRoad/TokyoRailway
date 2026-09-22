using System;
using System.Collections;
using System.Collections.Generic;

public static partial class Validation /* Range */ {

	//======================================================================| Value

	public static ValidationResult IsInRangeInclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) <= 0 && value.CompareTo(to) <= 0,
			() => new(
				$"[mention] must be in inclusive range [{from}, {to}]."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)
		);


	public static ValidationResult IsInRangeExclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) < 0 && value.CompareTo(to) < 0,
			() => new(
				$"[mention] must be in exclusive range ({from}, {to})."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)
		);

	public static ValidationResult IsInRangeInclusiveExclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) <= 0 && value.CompareTo(to) < 0,
			() => new(
				$"[mention] must be in range [{from}, {to})."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)	
		);

	public static ValidationResult IsInRangeExclusiveInclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) < 0 && value.CompareTo(to) <= 0,
			() => new(
				$"[mention] must be in range ({from}, {to}]."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)	
		);

	public static ValidationResult IsNotInRangeInclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) > 0 || value.CompareTo(to) > 0,
			() => new(
				$"[mention] must not be in inclusive range [{from}, {to}]."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)
		);


	public static ValidationResult IsNotInRangeExclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) >= 0 || value.CompareTo(to) >= 0,
			() => new(
				$"[mention] must not be in exclusive range ({from}, {to})."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)
		);

	public static ValidationResult IsNotInRangeInclusiveExclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) > 0 || value.CompareTo(to) >= 0,
			() => new(
				$"[mention] must not be in range [{from}, {to})."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)	
		);

	public static ValidationResult IsNotInRangeExclusiveInclusive<TComparable>(
		TComparable value,
		TComparable from,
		TComparable to,
		string nameOfValue = null
	) where TComparable : IComparable<TComparable> =>
		Validate<InvalidOperationException>(
			from.CompareTo(value) >= 0 || value.CompareTo(to) > 0,
			() => new(
				$"[mention] must not be in range ({from}, {to}]."
					.MentionOrPronoun(nameOfValue, "value", "mention")
					.AddInfo("Actual value", value)
			)	
		);

	//======================================================================| Collection

	public static ValidationResult IsInRange<T>(
		int value,
		IReadOnlyCollection<T> collection,
		string nameOfValue = null,
		string nameOfCollection = null
	) =>
		Validate<InvalidOperationException>(
			0 <= value && value < collection.Count,
			() => new(
				$"[mentionValue] must be in range of [mentionCollection]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfCollection, "collection", "mentionCollection", false)
					.AddInfo("Actual value", value)
					.AddInfo("Actual range of collection", $"[0, {collection.Count})")
			)
		);
	
	public static ValidationResult IsNotInRange<T>(
		int value,
		IReadOnlyCollection<T> collection,
		string nameOfValue = null,
		string nameOfCollection = null
	) =>
		Validate<InvalidOperationException>(
			0 > value || value >= collection.Count,
			() => new(
				$"[mentionValue] must not be in range of [mentionCollection]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfCollection, "collection", "mentionCollection", false)
					.AddInfo("Actual value", value)
					.AddInfo("Actual range of collection", $"[0, {collection.Count})")
			)
		);

	//======================================================================| Set

	public static ValidationResult IsInRange<TValue>(
		TValue value,
		ISet<TValue> set,
		string nameOfValue = null,
		string nameOfSet = null
	) =>
		Validate<InvalidCastException>(
			set.Contains(value),
			() => new(
				$"[mentionValue] must be in [mentionSet]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfSet, "set", "mentionSet", false)
					.AddInfo("Actual value", value)
			)
		);

	public static ValidationResult IsNotInRange<TValue>(
		TValue value,
		ISet<TValue> set,
		string nameOfValue = null,
		string nameOfSet = null
	) =>
		Validate<InvalidCastException>(
			!set.Contains(value),
			() => new(
				$"[mentionValue] must not be in [mentionSet]."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfSet, "set", "mentionSet", false)
					.AddInfo("Actual value", value)
			)
		);

	//======================================================================| Dictionary

	public static ValidationResult IsInRange<TKey, TValue>(
		TKey value,
		IDictionary<TKey, TValue> dictionary,
		string nameOfValue = null,
		string nameOfDictionary = null
	) =>
		Validate<InvalidCastException>(
			dictionary.ContainsKey(value),
			() => new(
				$"[mentionValue] must be in [mentionDictionary] as a key."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfDictionary, "dictionary", "mentionDictionary", false)
					.AddInfo("Actual value", value)
			)
		);

	public static ValidationResult IsNotInRange<TKey, TValue>(
		TKey value,
		IDictionary<TKey, TValue> dictionary,
		string nameOfValue = null,
		string nameOfDictionary = null
	) =>
		Validate<InvalidCastException>(
			!dictionary.ContainsKey(value),
			() => new(
				$"[mentionValue] must not be in [mentionDictionary] as a key."
					.MentionOrPronoun(nameOfValue, "value", "mentionValue")
					.MentionOrPronoun(nameOfDictionary, "dictionary", "mentionDictionary", false)
					.AddInfo("Actual value", value)
			)
		);

}