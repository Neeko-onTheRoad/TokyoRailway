using System.Collections.Generic;
using UnityEngine;

public record RailwayPointSegment {

	//======================================================================| Properties

	public IReadOnlyList<RailwayPointSample> Points { get; }
	public IReadOnlyCollection<RailwayPointConnection> Connections { get; }

	//======================================================================| Constructors

	public RailwayPointSegment(
		IReadOnlyList<RailwayPointSample> points,
		IReadOnlyCollection<RailwayPointConnection> connections
	) {

		Points = points;
		Connections = connections;

		if (Validation.Collection.IsCountGreaterThan(
			connections, nameof(connections), 3, out var exception
		)) throw exception;

	}

}