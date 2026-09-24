public class RailwayConnection {

	//======================================================================| Fields

	private RailwayJoint _joint = null;

	private readonly RailwaySegment _segment;
	private readonly RailwaySide _side;

	//======================================================================| Properties

	public RailwaySegment Segment => _segment;
	public RailwaySide Side => _side;

	public RailwayJoint Joint => _joint;
	public RailwaySide JointSide => _joint?.GetSide(this) ?? default;

	//======================================================================| Constructors

	public RailwayConnection(RailwaySegment segment, RailwaySide side) {
		_segment = segment;
		_side = side;
	}

	//======================================================================| Methods

	internal void SetJoint(RailwayJoint joint) {
		_joint = joint;
	}

	public void ConnectTo(RailwayConnection connection) {

		if (connection == this)
			return;

		if (connection.Joint is RailwayJoint joint) {
			var side = connection.JointSide.Opposite();
			joint.Join(this, side);
			return;
		}

		joint = new();
		joint.Join(this, RailwaySide.Front);
		joint.Join(connection, RailwaySide.Rear);

	}

}