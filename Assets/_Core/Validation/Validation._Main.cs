using System;
using System.Linq;

public static partial class Validation {

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

	private static string AddInfo(this string message, string name, object value)
		=> message += $"\n\t{name}: {value}";

	private static ValidationResult Validate<TException>(bool result, Func<TException> exception) where TException : Exception 
		=> new(result, result ? null : exception());

	public static void ThrowIfInvalid(params ValidationResult[] validations) {
		validations
			.Aggregate((prev, next) => prev + next)
			.ThrowIfInvalid();
	}

}