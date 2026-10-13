using System;
using System.Collections.Generic;
using UnityEngine;

public readonly struct RailwayCoordinate {

	//======================================================================| Properties

	public RailwaySegment Segment { get; }
	public RailwaySide Facing { get; }
	public float Position { get; }

	public readonly RailwayCoordinate Flipped => WithFacing(Facing.Opposite());
	public readonly float NormalizedPosition => Position / Segment.Length;

	//======================================================================| Constructors

	public RailwayCoordinate(RailwaySegment segment, RailwaySide facing, float position) {
		Segment = segment;
		Facing = facing;
		Position = position;
	}

	//======================================================================| Methods

	public readonly RailwayCoordinate WithSegment(RailwaySegment segment) => new(segment, Facing, Position);
	public readonly RailwayCoordinate WithFacing(RailwaySide facing) => new(Segment, facing, Position);
	public readonly RailwayCoordinate WithPosition(float position) => new(Segment, Facing, position);

	public readonly RailwaySample Evaluate() {

		var sample = Segment.EvaluateByLength(Position);
		if (Facing == RailwaySide.Front) sample = sample.Flipped;

		return sample;

	}

	public readonly RailwayCoordinate Move(float distance) {
		if (TryMove(distance, out var result)) return result;
		throw new InvalidOperationException("Railway coordinate out of range.");
	}

	public readonly bool TryMove(float distance, out RailwayCoordinate coordinate) {

		var facing = Facing;
		var position = Position;
		var segment = Segment;

		var isDistanceNegative = distance < 0;
		var distanceRemaining = Math.Abs(distance);

		while (true) {

			var isBackward = isDistanceNegative ^ (facing == RailwaySide.Front);
			var remaining = isBackward
				? position
				: segment.Length - position;

			if (distanceRemaining <= remaining) {
				coordinate = new(
					segment,
					facing,
					isBackward
						? position - distanceRemaining
						: position + distanceRemaining
				);
				return true;
			}

			var connection = isBackward
				? segment.FrontConnection
				: segment.RearConnection;

			var nextConnection = connection.ActiveOppositeConnection;

			if (nextConnection is null) {
				coordinate = default;
				return false;
			}

			distanceRemaining -= remaining;
			segment = nextConnection.Segment;
			position = nextConnection.Side == RailwaySide.Front ? 0 : segment.Length;

			if (connection.Side == nextConnection.Side)
				facing = facing.Opposite();

		}

	}

	public RailwayCoordinate WithPhysicalDistance(
		float distance,
		RailwaySide side,
		float tolerance = 0.0005f,
		float maximumMultiplier = 2f
	) {

		if (TryWithPhysicalDistance(
			distance,
			side,
			out var result,
			tolerance,
			maximumMultiplier
		)) return result;

		throw new InvalidOperationException(
			"The point with given distance in maximum range was not found."
		);

	}
	
	public bool TryWithPhysicalDistance(
		float distance,
		RailwaySide side,
		out RailwayCoordinate coordinate,
		float tolerance = 0.0005f,
		float maximumMultiplier = 2f
	) {

		distance = Math.Abs(distance);

		var position = Evaluate().Position;
		var @this = this;

		float GetPhysicalDistance(float offset) {
			if (side == RailwaySide.Rear) offset *= -1f;
			var newPosition = @this.Move(offset).Evaluate().Position;
			return Vector3.Distance(position, newPosition);
		}

		var maximum = distance * maximumMultiplier;

		Stack<(
			float StartPoint,
			float EndPoint,
			float StartValue,
			float EndValue
		)> sections = new();

		sections.Push((0f, maximum, GetPhysicalDistance(0f), GetPhysicalDistance(maximum)));

		while (sections.Count > 0) {

			var (startPoint, endPoint, startValue, endValue) = sections.Pop();
			var length = endPoint - startPoint;

			var maximumPossibleValue = (startValue + endValue + length) / 2f;
			if (maximumPossibleValue < distance)
				continue;
				
			var halfPoint = (startPoint + endPoint) / 2f;
			var halfValue = GetPhysicalDistance(halfPoint);

			if (Math.Abs(halfValue - distance) <= tolerance) {

				if (side == RailwaySide.Rear) halfPoint *= -1f;
				coordinate = Move(halfPoint);
				
				return true;

			}

			if (length < tolerance) continue;

			sections.Push((halfPoint, endPoint, halfValue, endValue));
			sections.Push((startPoint, halfPoint, startValue, halfValue));

		}

		coordinate = default;
		return false;

	}

}