using System.ComponentModel;
using UnityEngine;

[EditorBrowsable(EditorBrowsableState.Never)]
public class TrainTest : MonoBehaviour {

	public TrainCar _trainCar;

	[Space]
	public RailwayNetwork _railway;
	public int _index;
	public RailwaySide _facing;
	
	[Space]
	public float _move;

	private void Update() {
		_trainCar.Coordinate = new RailwayCoordinate(
			_railway.Segments[_index],
			_facing,
			0f
		).Move(_move);
	}

}