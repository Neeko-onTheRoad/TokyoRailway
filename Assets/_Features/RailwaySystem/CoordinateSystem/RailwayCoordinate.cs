public struct RailwayCoordinate {

	//======================================================================| Properties

	public RailwaySegment Segment { get; set; }
	public RailwaySide Facing { get; set; }
	public float Position { get; set; }

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

}