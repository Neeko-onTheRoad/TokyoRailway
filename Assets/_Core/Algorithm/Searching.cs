using System;
using System.Collections.Generic;

public static class Searching {

	//======================================================================| Methods

	public static int FirstIdentity<TValue>(
		
		IReadOnlyList<TValue> list,
		int pivot,
		int minIndex = 0

	) where TValue : IComparable<TValue> {

		var target = list[pivot];
		int maxIndex = pivot;

		while (minIndex < maxIndex) {
			
			pivot = (minIndex + maxIndex) / 2;

			if (list[pivot].CompareTo(target) < 0) {
				minIndex = pivot + 1;
				continue;
			}
			
			maxIndex = pivot;

		}

		return minIndex;
		
	}

	public static int LastIdentity<TValue>(
	
		IReadOnlyList<TValue> list,
		int pivot,
		int? maxIndex = null

	) where TValue : IComparable<TValue> {

		maxIndex ??= list.Count - 1;

		var target = list[pivot];
		int minIndex = pivot;

		while (minIndex < maxIndex) {
			
			pivot = (minIndex + maxIndex.Value + 1) / 2;
			
			if (list[pivot].CompareTo(target) > 0) {
				maxIndex = pivot - 1;
				continue;
			}

			minIndex = pivot;

		}

		return minIndex;

	}
	
	public static int BinarySearch<TValue>(

		IReadOnlyList<TValue> list,
		TValue target,
		IdentityHandling identityHandling = IdentityHandling.Any

	) where TValue : IComparable<TValue> {

		int minIndex = 0;
		int maxIndex = list.Count - 1;

		while (minIndex <= maxIndex) {

			var pivot = (minIndex + maxIndex) / 2;
			var compare = list[pivot].CompareTo(target);

			if (compare < 0) {
				minIndex = pivot + 1;
				continue;
			}

			if (compare > 0) {
				maxIndex = pivot - 1;
				continue;
			}
			
			if (identityHandling == IdentityHandling.First) 
				return FirstIdentity(list, pivot, minIndex);

			else if (identityHandling == IdentityHandling.Last)
				return LastIdentity(list, pivot, maxIndex);

			return pivot;

		}

		return -1;

	}

	public static int MaximumLowerBound<TValue>(
	
		IReadOnlyList<TValue> list,
		TValue target,
		bool exclusive = false

	) where TValue : IComparable<TValue> {
		
		int minIndex = 0;
		int maxIndex = list.Count - 1;
		int result = -1;

		while (minIndex <= maxIndex) {

			var pivot = (minIndex + maxIndex) / 2;
			var compare = list[pivot].CompareTo(target);

			var isCandidate = exclusive
				? compare < 0
				: compare <= 0;

			if (isCandidate) {
				result = pivot;
				minIndex = pivot + 1;
				continue;
			}

			maxIndex = pivot - 1;

		}

		return result;

	}
	
	public static int MinimumUpperBound<TValue>(
	
		IReadOnlyList<TValue> list,
		TValue target,
		bool exclusive = false

	) where TValue : IComparable<TValue> {
				
		int minIndex = 0;
		int maxIndex = list.Count - 1;
		int result = -1;

		while (minIndex <= maxIndex) {

			var pivot = (minIndex + maxIndex) / 2;
			var compare = list[pivot].CompareTo(target);

			var isCandidate = exclusive
				? compare < 0
				: compare <= 0;

			if (isCandidate) {
				result = pivot;
				maxIndex = pivot - 1;
				continue;
			}

			maxIndex = pivot + 1;

		}

		return result;

	}

}