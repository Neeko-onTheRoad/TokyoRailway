using System.Collections.Generic;

public class RailwayJoint {

	//======================================================================| Fields

	public const int MaximumSwitchCount = 3;

	private int _frontSwitch = 0;
	private int _rearSwitch = 0;

	private List<RailwayConnection> _frontConnections;
	private List<RailwayConnection> _rearConnections;

	//======================================================================| Properties

	public RailwayConnection CurrentFrontConnection => _frontConnections[_frontSwitch];
	public RailwayConnection CurrentRearConnection => _rearConnections[_rearSwitch];

	public int FrontSwitch {
		get => _frontSwitch;
		set {

			Validation.ThrowIfInvalid(
				Validation.IsBiggerThanOrEqualTo(value, 0),
				Validation.IsSmallerThan(value, MaximumSwitchCount)
			);

			_frontSwitch = value;

		}
	}

	public int RearSwitch {
		get => _rearSwitch;
		set {

			Validation.ThrowIfInvalid(
				Validation.IsBiggerThanOrEqualTo(value, 0),
				Validation.IsSmallerThan(value, MaximumSwitchCount)
			);

			_rearSwitch = value;

		}
	}

	//======================================================================| Methods

	public void Join(RailwayConnection connection, RailwaySide side) {

		if (side == RailwaySide.Front) {

			_frontConnections.Add(connection);

			Validation
				.IsSmallerThanOrEqualTo(
					_frontConnections.Count,
					MaximumSwitchCount,
					$"Count of {nameof(_frontConnections)}",
					nameof(MaximumSwitchCount)
				)
				.ThrowIfInvalid();

			return;

		}

		if (side == RailwaySide.Rear) {

			_rearConnections.Add(connection);

			Validation
				.IsSmallerThanOrEqualTo(
					_rearConnections.Count,
					MaximumSwitchCount,
					$"Count of {nameof(_rearConnections)}",
					nameof(MaximumSwitchCount)
				)
				.ThrowIfInvalid();

			return;

		}

	}

	public void Unjoin(RailwayConnection connection, RailwaySide side) {
		
		if (side == RailwaySide.Front) {

			var index = _frontConnections.IndexOf(connection);
			if (index < 0) return;

			_frontConnections.RemoveAt(index);
			return;

		}

		if (side == RailwaySide.Rear) {

			var index = _rearConnections.IndexOf(connection);
			if (index < 0) return;

			_rearConnections.RemoveAt(index);
			return;

		}

	}

}