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

}