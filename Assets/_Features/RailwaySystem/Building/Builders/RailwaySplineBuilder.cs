using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class RailwaySplineBuilder : RailwayBuilder {

	//======================================================================| Fields

	[SerializeField, Min(0.001f)]
	private float _sampleInterval;

	[SerializeField]
	private SplineContainer[] _containers;

	private readonly List<RailwaySegment> _segments = new();

	private readonly HashSet<RailwayConnection> _jointVisited = new();
	private readonly Dictionary<RailwayConnection, ConnectionIndexInfo> _indexInfo = new();
	private readonly Dictionary<(SplineContainer, SplineKnotIndex), HashSet<RailwayConnection>> _connectionsByIndex = new();

	//======================================================================| Properties

	public IReadOnlyList<RailwaySegment> Segments => _segments;

	//======================================================================| Methods

	public override IReadOnlyCollection<RailwaySegment> Build() {

		_segments.Clear();
		_jointVisited.Clear();
		_indexInfo.Clear();
		_connectionsByIndex.Clear();

		BuildAllContainers();
		BuildAllJoints();

		return _segments;

	}

	private void BuildAllContainers() {
		foreach (var container in _containers) {
			BuildContainer(container);
		}
	}

	private void BuildContainer(SplineContainer container) {
		for (int i = 0; i < container.Splines.Count; i++) {
			BuildSpline(container, i);
		}
	}

	private void BuildSpline(SplineContainer container, int splineIndex) {

		var spline = container[splineIndex];
		if (spline.Count < 2) return;

		int startIndex = 0;

		for (int endIndex = 1; endIndex < spline.Count; endIndex++) {

			SplineKnotIndex index = new(splineIndex, endIndex);

			bool isLast = endIndex == spline.Count - 1;
			bool isLinked = container.KnotLinkCollection.TryGetKnotLinks(index, out _);

			if (!isLast && !isLinked) continue;

			var segment = BuildSegment(container, splineIndex, startIndex, endIndex);
			_segments.Add(segment);

			Register(startIndex, 1, segment.FrontConnection);
			Register(endIndex, -1, segment.RearConnection);

			startIndex = endIndex;
			
			void Register(int knotIndex, int offset, RailwayConnection connection) {

				_indexInfo[connection] = new(
					container,
					new(splineIndex, knotIndex)
				);

				var key = (container, new SplineKnotIndex(splineIndex, knotIndex));

				if (!_connectionsByIndex.TryGetValue(key, out var connections)) {
					connections = new();
					_connectionsByIndex.Add(key, connections);
				}

				connections.Add(connection);

			}

		}

	}

	private RailwaySegment BuildSegment(SplineContainer container, int splineIndex, int startIndex, int endIndex) {

		var spline = container[splineIndex];

		var startDistance = spline.GetLengthBetween(0, startIndex);
		var segmentLength = spline.GetLengthBetween(startIndex, endIndex);

		int intervalCount = Mathf.Max(1, Mathf.CeilToInt(segmentLength / _sampleInterval));

		List<RailwaySample> samples = new(intervalCount + 1);

		for (int i = 0; i <= intervalCount; i++) {

			var progress = (float)i / intervalCount;
			var distance = startDistance + segmentLength * progress;

			var parameter = SplineUtility.GetNormalizedInterpolation(
				spline,
				distance,
				PathIndexUnit.Distance
			);

			container.Evaluate(
				splineIndex,
				parameter,
				out var position,
				out var tangent,
				out var normal
			);

			tangent = tangent.ToVector3().normalized;
			normal = Vector3.ProjectOnPlane(normal, tangent).normalized;

			samples.Add(new(position, tangent, normal));

		}

		return new(samples);

	}

	private void BuildAllJoints() {
		foreach (var connection in _indexInfo.Keys) {
			if (_jointVisited.Contains(connection)) continue;
			BuildJoint(connection);
		}
	}

	private void BuildJoint(RailwayConnection seed) {

		_jointVisited.Add(seed);

		var seedInfo = _indexInfo[seed];

		var container = seedInfo.Container;
		var index = seedInfo.Index;
		var seedTangent = GetOutwardTangent(seed);

		RailwayJoint joint = new();
		joint.Join(seed, RailwaySide.Front);

		HashSet<SplineKnotIndex> indices = new() { index };

		if (container.KnotLinkCollection.TryGetKnotLinks(index, out var links)) {
			foreach (var link in links) {
				indices.Add(link);
			}
		}

		foreach (var linkedIndex in indices) {

			if (!_connectionsByIndex.TryGetValue((container, linkedIndex), out var connections))
				continue;

			foreach (var connection in connections) {

				if (connection == seed)
					continue;

				var linkedTangent = GetOutwardTangent(connection);

				var side = Vector2.Dot(seedTangent, linkedTangent) >= 0f
					? RailwaySide.Front
					: RailwaySide.Rear;

				joint.Join(connection, side);
				_jointVisited.Add(connection);

			}

		}

	}

	private Vector2 GetOutwardTangent(RailwayConnection connection) {

		var info = _indexInfo[connection];

		var tangent = info.Container
			.GetTangent(info.Index)
			.WithoutY()
			.normalized;

		if (connection.Side == RailwaySide.Rear)
			tangent *= -1f;

		return tangent;

	}

	//======================================================================| Nested Types

	private record ConnectionIndexInfo(
		SplineContainer Container,
		SplineKnotIndex Index
	);

}