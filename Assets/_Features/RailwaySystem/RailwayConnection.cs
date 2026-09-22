public class RailwayConnection {

	//======================================================================| Fields

	private RailwaySegment _segment;
	private RailwayJoint _joint = null;
	private RailwaySide _side;

	//======================================================================| Constructors

	public RailwayConnection(RailwaySegment segment, RailwaySide side) {
		_segment = segment;
		_side = side;
	}

	//======================================================================| Methods

	public void ConnectTo(RailwayConnection connection) {

		if (_joint?.Unjoin(this, _side))

	}

}