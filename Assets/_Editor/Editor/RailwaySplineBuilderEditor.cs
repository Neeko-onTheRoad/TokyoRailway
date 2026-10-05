using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RailwaySplineBuilder))]
public class RailwaySplineBuilderEditor : Editor {

	//======================================================================| Constants

	private const float JointHandleSize = 0.12f;
	private const float ArrowSize = 0.7f;

	private const float PopupWidth = 240f;

	private static readonly Color LimeGreen = new(0.5f, 1f, 0f);

	//======================================================================| Fields

	private RailwayJoint _selectedJoint;

	//======================================================================| Unity Events

	private void OnSceneGUI() {

		var builder = (RailwaySplineBuilder)target;
		var joints = GetJoints(builder.Segments);

		foreach (var joint in joints) {
			DrawJoint(joint);
		}

		if (_selectedJoint != null) {
			DrawJointPopup(_selectedJoint);
		}

	}

	//======================================================================| Joint Drawing

	private void DrawJoint(RailwayJoint joint) {

		if (!TryGetJointPosition(joint, out var position))
			return;

		DrawConnections(
			joint.FrontConnections,
			joint.FrontSwitch,
			Color.magenta,
			Color.red
		);

		DrawConnections(
			joint.RearConnections,
			joint.RearSwitch,
			LimeGreen,
			Color.blue
		);

		DrawJointHandle(joint, position);

	}

	private void DrawConnections(

		IReadOnlyList<RailwayConnection> connections,
		int selectedIndex,
		Color normalColor,
		Color selectedColor

	) {

		for (int i = 0; i < connections.Count; i++) {

			var connection = connections[i];

			if (!TryGetConnectionPose(
				connection,
				out var position,
				out var direction
			)) {
				continue;
			}

			var color = i == selectedIndex
				? selectedColor
				: normalColor;

			DrawArrow(position, direction, color);

		}

	}

	private void DrawJointHandle(RailwayJoint joint, Vector3 position) {

		var size =
			HandleUtility.GetHandleSize(position)
			* JointHandleSize;

		Handles.color = Color.yellow;

		if (!Handles.Button(
			position,
			Quaternion.identity,
			size,
			size,
			Handles.SphereHandleCap
		)) {
			return;
		}

		_selectedJoint = _selectedJoint == joint
			? null
			: joint;

		SceneView.RepaintAll();

	}

	private static void DrawArrow(
		Vector3 position,
		Vector3 direction,
		Color color
	) {

		if (direction.sqrMagnitude <= Mathf.Epsilon)
			return;

		direction.Normalize();

		var size =
			HandleUtility.GetHandleSize(position)
			* ArrowSize;

		Handles.color = color;

		Handles.ArrowHandleCap(
			0,
			position,
			Quaternion.LookRotation(direction),
			size,
			EventType.Repaint
		);

	}

	//======================================================================| Popup

	private void DrawJointPopup(RailwayJoint joint) {

		if (!TryGetJointPosition(joint, out var position)) {

			_selectedJoint = null;
			return;

		}

		var guiPosition = HandleUtility.WorldToGUIPoint(position);

		var height =
			80f
			+ joint.FrontConnections.Count * 24f
			+ joint.RearConnections.Count * 24f;

		var rect = new Rect(
			guiPosition.x + 15f,
			guiPosition.y + 15f,
			PopupWidth,
			height
		);

		Handles.BeginGUI();

		GUILayout.BeginArea(
			rect,
			"Railway Joint",
			GUI.skin.window
		);

		DrawSwitchSelector(
			"Front",
			joint.FrontConnections,
			joint.FrontSwitch,
			Color.red,
			index => joint.FrontSwitch = index
		);

		EditorGUILayout.Space(5f);

		DrawSwitchSelector(
			"Rear",
			joint.RearConnections,
			joint.RearSwitch,
			Color.blue,
			index => joint.RearSwitch = index
		);

		EditorGUILayout.Space(5f);

		if (GUILayout.Button("Close")) {
			_selectedJoint = null;
		}

		GUILayout.EndArea();

		Handles.EndGUI();

	}

	private static void DrawSwitchSelector(

		string label,
		IReadOnlyList<RailwayConnection> connections,
		int selectedIndex,
		Color selectedColor,
		System.Action<int> select

	) {

		EditorGUILayout.LabelField(
			label,
			EditorStyles.boldLabel
		);

		for (int i = 0; i < connections.Count; i++) {

			var connection = connections[i];
			var isSelected = i == selectedIndex;

			var previousColor = GUI.backgroundColor;

			if (isSelected) {
				GUI.backgroundColor = selectedColor;
			}

			var buttonLabel =
				$"{i}: Segment {connection.Side}";

			if (GUILayout.Button(buttonLabel)) {
				select(i);
				SceneView.RepaintAll();
			}

			GUI.backgroundColor = previousColor;

		}

	}

	//======================================================================| Connection Pose

	private static bool TryGetConnectionPose(
		RailwayConnection connection,
		out Vector3 position,
		out Vector3 direction
	) {

		var samples = connection.Segment.Samples;

		if (samples.Count < 2) {

			position = default;
			direction = default;

			return false;

		}

		if (connection.Side == RailwaySide.Front) {

			position = samples[0].Position;
			direction =
				samples[1].Position
				- samples[0].Position;

		}
		else {

			position = samples[^1].Position;
			direction =
				samples[^2].Position
				- samples[^1].Position;

		}

		direction.Normalize();

		return true;

	}

	private static bool TryGetJointPosition(
		RailwayJoint joint,
		out Vector3 position
	) {

		position = Vector3.zero;

		var count = 0;

		foreach (var connection in joint.FrontConnections) {

			if (!TryGetConnectionPose(
				connection,
				out var connectionPosition,
				out _
			)) {
				continue;
			}

			position += connectionPosition;
			count++;

		}

		foreach (var connection in joint.RearConnections) {

			if (!TryGetConnectionPose(
				connection,
				out var connectionPosition,
				out _
			)) {
				continue;
			}

			position += connectionPosition;
			count++;

		}

		if (count == 0)
			return false;

		position /= count;

		return true;

	}

	//======================================================================| Collection

	private static HashSet<RailwayJoint> GetJoints(
		IReadOnlyList<RailwaySegment> segments
	) {

		HashSet<RailwayJoint> joints = new();

		foreach (var segment in segments) {

			var frontJoint = segment.FrontConnection.Joint;
			var rearJoint = segment.RearConnection.Joint;

			if (frontJoint != null) {
				joints.Add(frontJoint);
			}

			if (rearJoint != null) {
				joints.Add(rearJoint);
			}

		}

		return joints;

	}

}