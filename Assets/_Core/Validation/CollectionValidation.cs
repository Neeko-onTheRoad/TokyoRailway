using System;
using System.Collections.Generic;

public static partial class Validation /* collection */ {

	public static class Collection {

		public static bool IsEmpty<T>(IReadOnlyCollection<T> collection, string name, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count == 0,
				$"The collection '{name}' must contain elements.",
				out exception
			);

		public static bool IsCountEqualTo<T>(IReadOnlyCollection<T> collection, string name, int count, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count == count,
				$"The collection '{name}' must not contain {count} elements.",
				out exception
			);

		public static bool IsCountNotEqualTo<T>(IReadOnlyCollection<T> collection, string name, int count, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count != count,
				$"The collection '{name}' must contain {count} elements.",
				out exception
			);

		public static bool IsCountGreaterThan<T>(IReadOnlyCollection<T> collection, string name, int count, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count > count,
				$"The collection '{name}' must contain no more than {count} elements.",
				out exception
			);

		public static bool IsCountLessThen<T>(IReadOnlyCollection<T> collection, string name, int count, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count < count,
				$"The collection '{name}' must contain no fewer then {count} elements.",
				out exception
			);

		public static bool IsCountGreaterThenOrEqualTo<T>(IReadOnlyList<T> collection, string name, int count, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count >= count,
				$"The collection '{name}' must contain fewer then {count} elements.",
				out exception
			);

		public static bool IsCountLessThenOrEqualTo<T>(IReadOnlyList<T> collection, string name, int count, out InvalidOperationException exception) =>
			Validate(
				() => collection.Count <= count,
				$"The collection '{name}' must contain more then {count} elements.",
				out exception
			);

		public static bool IsCountNotEqualTo<T1, T2>(IReadOnlyList<T1> collection1, string name1, IReadOnlyList<T2> collection2, string name2, out InvalidOperationException exception) =>
			Validate(
				() => collection1.Count != collection2.Count,
				$"The collection '{name1}' and '{name2}' must contain same amount of elements.",
				out exception
			);

	}

}