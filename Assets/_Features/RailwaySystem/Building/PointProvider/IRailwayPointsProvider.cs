using System.Collections.Generic;

public interface IRailwayPointsProvider {

	public IReadOnlyCollection<RailwayPointSegment> Segments { get; }

}