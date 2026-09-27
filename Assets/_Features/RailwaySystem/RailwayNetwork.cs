using UnityEngine;
using System.Collections.Generic;

public class RailwayNetwork : MonoBehaviour {

	//======================================================================| Fields

	[SerializeField]
	private RailwayBuilder _builder;

	//======================================================================| Properties

	public IReadOnlyCollection<RailwaySegment> Segments { get; private set; }

	//======================================================================| Unity Methods

	private void Awake() {
		Segments = _builder.Build();
	}

}