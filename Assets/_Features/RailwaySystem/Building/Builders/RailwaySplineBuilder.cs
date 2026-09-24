using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class RailwaySplineBuilder : RailwayBuilder {

	//======================================================================| Fields

	[SerializeField]
	private float _sampleInterval;

	[SerializeField]
	private SplineContainer[] _containers;

	private readonly List<RailwaySegment> _segments = new();
	private readonly List<(RailwayConnection[], RailwayConnection[])> _joints = new();

	private HashSet<RailwayConnection> _jointVisited = new();
	private Dictionary<RailwayConnection, (SplineContainer, SplineKnotIndex)> _indices = new();

	//======================================================================| Unity Methods

	private void Start() {

		BuildAllContainers();
		BuildAllJoints();

		_indices = null;
		_jointVisited = null;

	}

	//======================================================================| Methods

	protected override IEnumerable<RailwaySegment> GetSegments() => _segments;
	protected override IEnumerable<(RailwayConnection[], RailwayConnection[])> GetJoints() => _joints;

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

		int startIndex = 0;
		int endIndex = 0;

		var spline = container[splineIndex];

		while (startIndex < spline.Count) {

			endIndex++;

			if (container.AreKnotLinked(
				new(splineIndex, startIndex),
				new(splineIndex, endIndex)
			)) {

				var segment = BuildSegment(spline, startIndex, endIndex);
				
				_segments.Add(segment);
				_indices[segment.FrontConnection] = (container, new(splineIndex, startIndex));
				_indices[segment.RearConnection] = (container, new(splineIndex, endIndex));
				
				startIndex = endIndex;
			}

		}

	}

	private RailwaySegment BuildSegment(Spline spline, int startIndex, int endIndex) {

		var splineLength = spline.GetLength();
		var startPoint = spline.GetLengthBetween(0, startIndex);
		var segmentLength = spline.GetLengthBetween(startIndex, endIndex);
		var sampleCount = Mathf.CeilToInt(segmentLength / _sampleInterval);

		List<RailwaySample> samples = new();

		for (int i = 0; i < sampleCount; i++) {

			var progress = (float)i / sampleCount;
			var parameter = (startPoint + progress * segmentLength) / splineLength;

			spline.Evaluate(parameter,
				out var position,
				out var tangent,
				out var normal
			);

			samples.Add(new(position, tangent, normal));

		}

		return new(samples);

	}

	private void BuildAllJoints() {

		foreach (var segment in _segments) {

			if (!_jointVisited.Contains(segment.FrontConnection))
				BuildJoint(segment.FrontConnection);

			if (!_jointVisited.Contains(segment.RearConnection))
				BuildJoint(segment.RearConnection);

		}

	}

	private void BuildJoint(RailwayConnection seed) {

		var (container, index) = _indices[seed];
		var links = container.KnotLinkCollection.GetKnotLinks(index);

		// TODO: from here, build some joint shit
		//       what you need to do is just combine some connections by links.

	}

}