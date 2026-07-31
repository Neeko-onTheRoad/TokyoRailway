using System;

public static partial class aValidation {

	private static string WithOptionalName(this string message, string identifier, string type, string name) {

		name = string.IsNullOrEmpty(name) ? "" : $" '{name}'";
		name = $"{type}{name}";

		return message.Replace($"[{identifier}]", name, StringComparison.CurrentCultureIgnoreCase);

	}

	private static string WithInfo(this string message, string tagName, object value) =>
		message + $"\n{tagName}: {value}";

	public static bool Validate(Func<bool> criteria, out InvalidOperationException exception, string failureMessage) {

		if (criteria()) {
			exception = default;
			return true;
		}

		exception = new(failureMessage);
		return false;

	}

}