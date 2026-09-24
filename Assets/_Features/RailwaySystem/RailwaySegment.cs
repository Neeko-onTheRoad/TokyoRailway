using System.Collections.Generic;
using UnityEngine;

public class RailwaySegment {

	//======================================================================| Fields

	private readonly List<RailwaySample> _samples;
	private readonly List<float> _samplePosition;

	public readonly RailwayConnection FrontConnection;
	public readonly RailwayConnection RearConnection;

	//======================================================================| Properties

	public float Length { get; private set; }
	public IReadOnlyList<RailwaySample> Samples => _samples;

	//======================================================================| Constructors

	public RailwaySegment(IEnumerable<RailwaySample> samples) {
		
		FrontConnection = new(this, RailwaySide.Front);
		RearConnection = new(this, RailwaySide.Rear);

		_samplePosition = new() { 0f };
		_samples = new();
		_samples.AddRange(samples);

		var currentLength = 0f;

		for (int i = 1; i < _samples.Count; i++) {

			_samplePosition.Add(currentLength);
			
			currentLength += Vector3.Distance(
				_samples[i - 1].Position,
				_samples[i].Position
			);

		}

		Length = currentLength;

	}

	//======================================================================| Methods

	public RailwaySample Evaluate(float factor, RailwaySide startingSide = RailwaySide.Front)
		=> EvaluateByLength(factor * Length, startingSide);

	public RailwaySample EvaluateByLength(float length, RailwaySide startingSide = RailwaySide.Front) {

		Validation.ThrowIfInvalid(
			Validation.IsBiggerThanOrEqualTo(length, 0, nameof(length)),
			Validation.IsSmallerThanOrEqualTo(length, Length, nameof(length))
		);

		if (Mathf.Approximately(length, Length)) 
			return _samples[^1];

		if (startingSide == RailwaySide.Rear)
			length = Length - length;
		
		var index = Searching.MaximumLowerBound(_samplePosition, length);
		var intervalLength = _samplePosition[index + 1] - _samplePosition[index];

		var localLength = _samplePosition[index] - length;
		var factor = localLength / intervalLength;

		return RailwaySample.Lerp(_samples[index], _samples[index + 1], factor);

	}

}