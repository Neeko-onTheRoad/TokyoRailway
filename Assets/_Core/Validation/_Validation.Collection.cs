using System;
using System.Collections.Generic;

public static partial class aValidation /* collection */ {

	public static class Collection {

		public static bool IsEmpty<T>(IReadOnlyCollection<T> collection, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count == 0,
				out failureException,
				"[name] must contain elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsNotEmpty<T>(IReadOnlyCollection<T> collection, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count != 0,
				out failureException,
				"[name] must bit contain elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsCountEqualTo<T>(IReadOnlyCollection<T> collection, int count, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count == count,
				out failureException,
				$"[name] must contain {count} elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsCountNotEqualTo<T>(IReadOnlyCollection<T> collection, int count, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count != count,
				out failureException,
				$"[name] must not contain {count} elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsCountGreaterThan<T>(IReadOnlyCollection<T> collection, int count, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count > count,
				out failureException,
				$"[name] must contain more than {count} elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsCountLessThan<T>(IReadOnlyCollection<T> collection, int count, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count < count,
				out failureException,
				$"[name] must contain fewer than {count} elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsCountGreaterThanOrEqualTo<T>(IReadOnlyCollection<T> collection, int count, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count >= count,
				out failureException,
				$"[name] must contain no fewer than {count} elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);

		public static bool IsCountLessThanOrEqualTo<T>(IReadOnlyCollection<T> collection, int count, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => collection.Count <= count,
				out failureException,
				$"[name] must contain no more than {count} elements."
					.WithOptionalName("name", "The collection", name)
					.WithInfo("Actual count", collection.Count)
			);
		
		public static bool IsCountEqualTo<T1, T2>(IReadOnlyCollection<T1> collection1, IReadOnlyCollection<T2> collection2, out InvalidOperationException failureException, string name1 = null, string name2 = null) =>
			Validate(
				() => collection1.Count == collection2.Count,
				out failureException,
				"[collections] must contain same number of elements."
					.Replace("[collections]",
						(name1, name2) switch {
							(string, null) => $"The collection '{name1}' and the given collection",
							(null, string) => $"The given collection and '{name2}'",
							_ => "The two collections"
						}
					)
					.WithInfo("Actual count 1", collection1.Count)
					.WithInfo("Actual count 2", collection2.Count)
			);

		public static bool IsCountNotEqualTo<T1, T2>(IReadOnlyCollection<T1> collection1, IReadOnlyCollection<T2> collection2, out InvalidOperationException failureException, string name1 = null, string name2 = null) =>
			Validate(
				() => collection1.Count != collection2.Count,
				out failureException,
				"[collections] must not contain same number of elements."
					.Replace("[collections]",
						(name1, name2) switch {
							(string, null) => $"The collection '{name1}' and the given collection",
							(null, string) => $"The given collection and '{name2}'",
							_ => "The two collections"
						}
					)
					.WithInfo("Actual count 1", collection1.Count)
					.WithInfo("Actual count 2", collection2.Count)
			);

	}

}