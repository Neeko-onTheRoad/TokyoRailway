using System;
using System.Numerics;

public static partial class aValidation /* Range */ {

	public static class Range {

		public static bool IsInRange(int value, int rangeStart, int rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(int value, int rangeStart, int rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(int value, int rangeStart, int rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(int value, int rangeStart, int rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(uint value, uint rangeStart, uint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(uint value, uint rangeStart, uint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(uint value, uint rangeStart, uint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(uint value, uint rangeStart, uint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(short value, short rangeStart, short rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(short value, short rangeStart, short rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(short value, short rangeStart, short rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(short value, short rangeStart, short rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(ushort value, ushort rangeStart, ushort rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(ushort value, ushort rangeStart, ushort rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(ushort value, ushort rangeStart, ushort rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(ushort value, ushort rangeStart, ushort rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(sbyte value, sbyte rangeStart, sbyte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(sbyte value, sbyte rangeStart, sbyte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(sbyte value, sbyte rangeStart, sbyte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(sbyte value, sbyte rangeStart, sbyte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(byte value, byte rangeStart, byte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(byte value, byte rangeStart, byte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(byte value, byte rangeStart, byte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(byte value, byte rangeStart, byte rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(char value, char rangeStart, char rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(char value, char rangeStart, char rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(char value, char rangeStart, char rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(char value, char rangeStart, char rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(nint value, nint rangeStart, nint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(nint value, nint rangeStart, nint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(nint value, nint rangeStart, nint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(nint value, nint rangeStart, nint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(nuint value, nuint rangeStart, nuint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(nuint value, nuint rangeStart, nuint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(nuint value, nuint rangeStart, nuint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(nuint value, nuint rangeStart, nuint rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(long value, long rangeStart, long rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(long value, long rangeStart, long rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(long value, long rangeStart, long rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(long value, long rangeStart, long rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(ulong value, ulong rangeStart, ulong rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(ulong value, ulong rangeStart, ulong rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(ulong value, ulong rangeStart, ulong rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(ulong value, ulong rangeStart, ulong rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(float value, float rangeStart, float rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(float value, float rangeStart, float rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(float value, float rangeStart, float rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(float value, float rangeStart, float rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(double value, double rangeStart, double rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(double value, double rangeStart, double rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(double value, double rangeStart, double rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(double value, double rangeStart, double rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(decimal value, decimal rangeStart, decimal rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(decimal value, decimal rangeStart, decimal rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(decimal value, decimal rangeStart, decimal rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(decimal value, decimal rangeStart, decimal rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRange(BigInteger value, BigInteger rangeStart, BigInteger rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart <= value && value <= rangeEnd,
				out failureException,
				$"[name] must be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRange(BigInteger value, BigInteger rangeStart, BigInteger rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value < rangeStart || rangeEnd < value,
				out failureException,
				$"[name] must not be in the inclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsInRangeExclusive(BigInteger value, BigInteger rangeStart, BigInteger rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => rangeStart < value && value < rangeEnd,
				out failureException,
				$"[name] must be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

		public static bool IsNotInRangeExclusive(BigInteger value, BigInteger rangeStart, BigInteger rangeEnd, out InvalidOperationException failureException, string name = null) =>
			Validate(
				() => value <= rangeStart || rangeEnd <= value,
				out failureException,
				$"[name] must not be in the exclusive range [{rangeStart}, {rangeEnd}]."
					.WithOptionalName("name", "The value", name)
					.WithInfo("Actual value", value)
			);

	}

}