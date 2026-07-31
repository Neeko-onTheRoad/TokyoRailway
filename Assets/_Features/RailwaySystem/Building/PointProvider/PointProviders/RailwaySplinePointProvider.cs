using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(SplineContainer))]
public class RailwaySplinePointProvider : MonoBehaviour, IRailwayPointsProvider {

	//======================================================================| Fields

	[SerializeField]
	private float _sampleDistance;

	private SplineContainer _splineContainer;

	//======================================================================| Properties

	public IReadOnlyCollection<RailwayPointSegment> Segments => GetSegments();

	//======================================================================| UnityMethods

	private void Awake() {
		_splineContainer = GetComponent<SplineContainer>();
	}

	//======================================================================| Methods

	private IReadOnlyCollection<RailwayPointSegment> GetSegments() {
		
		List<RailwayPointSegment> segments = new();

		for (int i = 0; i < _splineContainer.Splines.Count; i++) {
			var spline = _splineContainer.Splines[i];
			segments.AddRange(MakeSegmentsWithSpline(spline, i, _splineContainer.KnotLinkCollection));
		}

		return segments;

	}

	private IEnumerable<RailwayPointSegment> MakeSegmentsWithSpline(Spline spline, int splineIndex, KnotLinkCollection linkCollection) {

		for (int i = 0; i < spline.Count; i++) {
			
			var knot = spline[i];
			var links = linkCollection.GetKnotLinks(new(splineIndex, i));
			
			var sampleCount = (int)Mathf.Max(2f, spline.GetLength() / _sampleDistance);

		}
		
	}

	private RailwayPointSegment MakeSegment(Spline spline, int startKnot, int endKnot) {
		
		

	}

}

