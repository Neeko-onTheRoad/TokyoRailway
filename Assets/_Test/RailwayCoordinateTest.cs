using System.Linq;
using UnityEngine;

public class RailwayCoordinateTest : MonoBehaviour {

	public RailwayNetwork Network;

	public int SegmentIndex = 0;

	[Range(0f, 1f)]
	public float SegmentPosition = 0f;
	public float Movement = 0f;

	private void OnDrawGizmos() {

		if (!Application.isPlaying) return;
	
		var previousGizmoColor = Gizmos.color;

		var segment = Network.Segments.ElementAt(SegmentIndex);
		Draw(segment, Color.red, Color.blue, 0.1f, 0.1f);

		var coordinate = new RailwayCoordinate(segment, RailwaySide.Front, segment.Length * SegmentPosition);
		var movedPosition = coordinate.Move(Movement);

		Gizmos.color = Color.red;
		Gizmos.DrawSphere(coordinate.Evaluate().Position, 0.5f);
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(movedPosition.Evaluate().Position, 0.5f);

		var (front, frontRev) = (
			segment.FrontConnection.Joint.FrontConnections,
			segment.FrontConnection.Joint.RearConnections
		);

		var (rear, rearRev) = (
			segment.RearConnection.Joint.FrontConnections,
			segment.RearConnection.Joint.RearConnections
		);

		if (segment.FrontConnection.JointSide == RailwaySide.Rear) 
			(front, frontRev) = (frontRev, front);

		if (segment.RearConnection.JointSide == RailwaySide.Rear)
			(rear, rearRev) = (rearRev, rear);

		foreach (var connection in front) {
			var tangent = connection.Side == RailwaySide.Rear
				? connection.Evaluate().Tangent
				: connection.Evaluate().Flipped.Tangent;
			DrawArrow.ForGizmo(segment.Evaluate(0f).Position, tangent, Color.green);
		}
		foreach (var connection in frontRev) {
			var tangent = connection.Side == RailwaySide.Rear
				? connection.Evaluate().Tangent
				: connection.Evaluate().Flipped.Tangent;
			DrawArrow.ForGizmo(segment.Evaluate(0f).Position, tangent, Color.magenta);
		}
		foreach (var connection in rear) {
			var tangent = connection.Side == RailwaySide.Rear
				? connection.Evaluate().Tangent
				: connection.Evaluate().Flipped.Tangent;
			DrawArrow.ForGizmo(segment.Evaluate(1f).Position, tangent, Color.green);
		}
		foreach (var connection in rearRev) {
			var tangent = connection.Side == RailwaySide.Rear
				? connection.Evaluate().Tangent
				: connection.Evaluate().Flipped.Tangent;
			DrawArrow.ForGizmo(segment.Evaluate(1f).Position, tangent, Color.magenta);
		}

		Gizmos.color = previousGizmoColor;

		static void Draw(RailwaySegment segment, Color s, Color e, float ss, float se) {
				
			int index = 0;
			foreach (var sample in segment.Samples) {
			
				var t = (float)index++ / (segment.Samples.Count - 1);

				Gizmos.color = Color.Lerp(s, e, t);
				Gizmos.DrawSphere(sample.Position, Mathf.Lerp(ss, se, t));

			}
		}

	}

}