using System.Collections.Generic;
using UnityEngine;

public abstract class RailwayBuilder : MonoBehaviour {

	public abstract IReadOnlyCollection<RailwaySegment> Build();

}