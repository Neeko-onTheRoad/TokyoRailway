using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RailwayJoint {

	//======================================================================| Fields

	public const int MaximumSwitchCount = 3;

	private int _frontSwitch = 0;
	private int _rearSwitch = 0;

	private readonly List<RailwayConnection> _frontConnections = new();
	private readonly List<RailwayConnection> _rearConnections = new();

	//======================================================================| Properties

	public RailwayConnection? CurrentFrontConnection =>
		_frontConnections.Count > 0 ? _frontConnections[_frontSwitch] : null;

	public RailwayConnection? CurrentRearConnection =>
		_rearConnections.Count > 0 ? _rearConnections[_rearSwitch] : null;

	public int FrontSwitch {
		get => _frontSwitch;
		set {

			Validation.ThrowIfInvalid(
				Validation.IsBiggerThanOrEqualTo(value, 0),
				Validation.IsSmallerThan(value, _frontConnections.Count)
			);

			_frontSwitch = value;

		}
	}

	public int RearSwitch {
		get => _rearSwitch;
		set {

			Validation.ThrowIfInvalid(
				Validation.IsBiggerThanOrEqualTo(value, 0),
				Validation.IsSmallerThan(value, _rearConnections.Count)
			);

			_rearSwitch = value;

		}
	}

	//======================================================================| Methods

	public void Unjoin(RailwayConnection connection) {

		RemoveConnection(
			_frontConnections,
			connection,
			ref _frontSwitch
		);

		RemoveConnection(
			_rearConnections,
			connection,
			ref _rearSwitch
		);

		if (connection.Joint == this)
			connection.SetJoint(null);

	}
	
	public void Join(RailwayConnection connection, RailwaySide side) {
	
		var connections = GetConnections(side);

		if (connections.Contains(connection)) return;

		Validation
			.IsSmallerThan(
				connections.Count,
				MaximumSwitchCount,
				$"Count of {nameof(connections)}",
				nameof(MaximumSwitchCount)
			)
			.ThrowIfInvalid();

		connection.Joint?.Unjoin(connection);
		
		connections.Add(connection);
		connection.SetJoint(this);

	}

	public RailwaySide GetSide(RailwayConnection connection) {
		if (_frontConnections.Contains(connection)) return RailwaySide.Front;
		if (_rearConnections.Contains(connection)) return RailwaySide.Rear;
		throw new InvalidOperationException();
	}

	public static RailwayJoint Combine(RailwayConnection from, RailwayConnection to) {

		if (from.Joint is not null && ReferenceEquals(from.Joint, to.Joint))
			return from.Joint;

		if (from.Joint is null) {
			from.ConnectTo(to);
			return to.Joint;
		}

		if (to.Joint is null) {
			to.ConnectTo(from);
			return from.Joint;
		}

		var targetConnections = from.Joint.GetConnections(from.JointSide).ToList();
		var oppositeConnections = from.Joint.GetConnections(from.JointSide.Opposite()).ToList();

		var targetSide = to.JointSide.Opposite();
		var oppositeSide = to.JointSide;

		Validation.ThrowIfInvalid(
			Validation.IsSmallerThanOrEqualTo(
				to.Joint.GetConnections(targetSide).Count + targetConnections.Count,
				MaximumSwitchCount,
				"Total count",
				nameof(MaximumSwitchCount)
			),
			Validation.IsSmallerThanOrEqualTo(
				to.Joint.GetConnections(oppositeSide).Count + oppositeConnections.Count,
				MaximumSwitchCount,
				"Total count",
				nameof(MaximumSwitchCount)
			)
		);

		foreach (var connection in targetConnections) {
			to.Joint.Join(connection, targetSide);
		}

		foreach (var connection in oppositeConnections) {
			to.Joint.Join(connection, oppositeSide);
		}

		return to.Joint;

	}

	private List<RailwayConnection> GetConnections(RailwaySide side) => side switch {
		RailwaySide.Front => _frontConnections,
		RailwaySide.Rear => _rearConnections,
		_ => throw new ArgumentOutOfRangeException(nameof(side))
	};

	private static bool RemoveConnection(
		List<RailwayConnection> connections,
		RailwayConnection connection,
		ref int switchIndex
	) {

		var index = connections.IndexOf(connection);

		if (index < 0) return false;

		connections.RemoveAt(index);

		if (index < switchIndex) switchIndex--;
		if (switchIndex >= connections.Count) switchIndex = Math.Max(0, connections.Count - 1);

		return true;
		
	}

}