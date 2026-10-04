public class RailwayConnection {

	//======================================================================| Properties

	public RailwaySegment Segment { get; }
	public RailwaySide Side { get; }

	public RailwayJoint Joint { get; private set; }
	public RailwaySide JointSide => Joint?.GetSide(this) ?? default;

	public RailwayConnection ActiveOppositeConnection => JointSide == RailwaySide.Front
		? Joint.ActiveRearConnection
		: Joint.ActiveRearConnection;

	public bool IsActiveOppositeConnectionReversed => Side != ActiveOppositeConnection.Side;

	//======================================================================| Constructors

	public RailwayConnection(RailwaySegment segment, RailwaySide side) {
		Segment = segment;
		Side = side;
	}

	//======================================================================| Methods
	
	public RailwaySample Evaluate() => Segment.Evaluate(0f, Side);

	internal void SetJoint(RailwayJoint joint) {
		Joint = joint;
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