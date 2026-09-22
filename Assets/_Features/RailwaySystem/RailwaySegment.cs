using System.Collections.Generic;
using UnityEngine;

public class RailwaySegment {

	//======================================================================| Fields

	private readonly List<RailwayPoint> _points;
	private readonly List<float> _pointPosition;

	//======================================================================| Properties

	public float Length { get; private set; }
	public IReadOnlyList<RailwayPoint> Points => _points;

	public RailwayConnection FrontConnection;
	public RailwayConnection RearConnection;

	//======================================================================| Constructors

	public RailwaySegment(IEnumerable<RailwayPoint> points) {
		
		_pointPosition = new() { 0f };
		_points = new();
		_points.AddRange(points);

		var currentLength = 0f;

		for (int i = 1; i < _points.Count; i++) {

			_pointPosition.Add(currentLength);
			
			currentLength += Vector3.Distance(
				_points[i - 1].Position,
				_points[i].Position
			);

		}

		Length = currentLength;

	}

	//======================================================================| Methods

	public RailwayPoint Evaluate(float factor, RailwaySide startingSide = RailwaySide.Front)
		=> EvaluateByLength(factor * Length, startingSide);

	public RailwayPoint EvaluateByLength(float length, RailwaySide startingSide = RailwaySide.Front) {

		Validation.ThrowIfInvalid(
			Validation.IsBiggerThanOrEqualTo(length, 0, nameof(length)),
			Validation.IsSmallerThanOrEqualTo(length, Length, nameof(length))
		);

		if (Mathf.Approximately(length, Length)) 
			return _points[^1];

		if (startingSide == RailwaySide.Rear)
			length = Length - length;
		
		var index = Searching.MaximumLowerBound(_pointPosition, length);
		var intervalLength = _pointPosition[index + 1] - _pointPosition[index];

		var localLength = _pointPosition[index] - length;
		var factor = localLength / intervalLength;

		return RailwayPoint.Lerp(_points[index], _points[index + 1], factor);

	}

}