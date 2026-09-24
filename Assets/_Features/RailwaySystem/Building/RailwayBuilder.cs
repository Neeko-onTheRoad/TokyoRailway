using System.Collections.Generic;
using UnityEngine;

public abstract class RailwayBuilder : MonoBehaviour {

	//======================================================================| Methods

	public IReadOnlyCollection<RailwaySegment> Build() {
		
		List<RailwaySegment> segments = new(GetSegments());

		foreach (var (frontConnections, rearConnections) in GetJoints()) {

			RailwayJoint joint = new();

			foreach (var connection in frontConnections)
				joint.Join(connection, RailwaySide.Front);
			
			foreach (var connection in rearConnections)
				joint.Join(connection, RailwaySide.Rear);

		}

		return segments;

	}

	protected abstract IEnumerable<RailwaySegment> GetSegments();
	protected abstract IEnumerable<(RailwayConnection[], RailwayConnection[])> GetJoints();

}