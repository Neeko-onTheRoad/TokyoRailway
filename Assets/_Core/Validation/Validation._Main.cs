using System;
using System.Runtime.CompilerServices;

public static partial class Validation {

	private static string AddInfo(this string message, string name, object value) =>
		message += $"\n\t{name}: {value}";

	private static string MentionOrPronoun(
		this string message,
		string name,
		string type,
		string identifier,
		bool startWithUpperCase = true
	) {

		var mention = startWithUpperCase ? "The " : "the ";
		mention += name == null ? $"{type}" : $"{type} '{name}'";

		return message.Replace($"[{identifier}]", mention, StringComparison.CurrentCultureIgnoreCase);

	}

	private static ValidationResult Validate<TException>(bool result, Func<TException> exception) where TException : Exception {
		return new(result, result ? null : exception());
	}

}