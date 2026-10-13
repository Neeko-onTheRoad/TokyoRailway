using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

[EditorBrowsable(EditorBrowsableState.Never)]
public class RailwayCoordinateTest : MonoBehaviour {

	public RailwayNetwork Network;

	public int SegmentIndex = 0;

	[Range(0f, 1f)]
	public float SegmentPosition = 0f;
	public float Movement = 0f;
	public float Physical = 0f;

	private void OnDrawGizmos() {

		if (!Application.isPlaying) return;
	
		var previousGizmoColor = Gizmos.color;

		var segment = Network.Segments.ElementAt(SegmentIndex);

		var coordinate = new RailwayCoordinate(segment, RailwaySide.Rear, segment.Length * SegmentPosition);
		var movedPosition = coordinate.Move(Movement);
		var physical = movedPosition.WithPhysicalDistance(Physical, RailwaySide.Rear);

		Gizmos.color = Color.red;
		Gizmos.DrawSphere(coordinate.Evaluate().Position, 0.5f);

		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(movedPosition.Evaluate().Position, 0.5f);
		Gizmos.DrawLine(movedPosition.Evaluate().Position, physical.Evaluate().Position);

		Gizmos.color = Color.purple;
		Gizmos.DrawSphere(physical.Evaluate().Position, 0.5f);

		Gizmos.color = previousGizmoColor;
		

	}

}