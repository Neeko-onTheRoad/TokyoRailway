using System;

public struct RailwayCoordinate {

	//======================================================================| Properties

	public RailwaySegment Segment { get; set; }
	public RailwaySide Facing { get; set; }
	public float Position { get; set; }

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

}