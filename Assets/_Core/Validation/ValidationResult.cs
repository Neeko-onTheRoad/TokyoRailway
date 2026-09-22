using System;

public readonly struct ValidationResult {

	//======================================================================| Properties

	public bool IsValid { get; }
	public Exception Exception { get; }

	//======================================================================| Constructors

	public ValidationResult(bool isValid = true, Exception exception = null) {
		IsValid = isValid;
		Exception = exception;
	}

	//======================================================================| Methods

	public void ThrowIfInvalid() {
		if (!IsValid) throw Exception ?? new();
	}

	//======================================================================| Operators

	public static ValidationResult operator +(ValidationResult left, ValidationResult right) {
		return new(
			left.IsValid || right.IsValid, 
			(left.IsValid, right.IsValid) switch {
				(true, true) => null,
				(false, true) => left.Exception,
				(true, false) => right.Exception,
				(false, false) => new AggregateException(left.Exception, right.Exception).Flatten()
			}
		);
	}

}