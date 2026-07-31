using System.Collections.Generic;

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

		if (!Validation.Collection.IsCountLessThanOrEqualTo(
			connections, 3, out var exception, nameof(connections)
		)) throw exception;

	}

}