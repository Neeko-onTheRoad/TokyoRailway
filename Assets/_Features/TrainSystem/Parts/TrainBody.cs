using UnityEngine;

public class TrainBody : TrainParts {

	//======================================================================| Field

	[SerializeField]
	private TrainBogie _frontBogie;

	[SerializeField]
	private TrainBogie _rearBogie;

	private float _distanceBetweenBogies;
	private float _lerpPointBetweenBogies;

	//======================================================================| Properties

	public TrainBogie FrontBogie => Car.IsReversed ? _rearBogie : _frontBogie;
	public TrainBogie RearBogie => Car.IsReversed ? _frontBogie : _rearBogie;

	//======================================================================| Unity Methods

	private void Awake() {

		_distanceBetweenBogies = Vector3.Distance(
			_frontBogie.transform.position,
			_rearBogie.transform.position
		);

		var bogieOffset = _rearBogie.SettlePoint - _frontBogie.SettlePoint;

		_lerpPointBetweenBogies = Vector3.Dot(
			transform.position - _frontBogie.SettlePoint, bogieOffset
		) / bogieOffset.sqrMagnitude;

	}

	//======================================================================| Methods

	public void UpdatePosition() {

		var pairCoordinate = Car.Coordinate.WithPhysicalDistance(
			_distanceBetweenBogies,
			RailwaySide.Rear
		);

		FrontBogie.MoveTo(Car.Coordinate);
		RearBogie.MoveTo(pairCoordinate);

		transform.SetPositionAndRotation(
			Vector3.Lerp(
				FrontBogie.SettlePoint,
				RearBogie.SettlePoint,
				_lerpPointBetweenBogies
			),
			Quaternion.LookRotation(
				(_frontBogie.SettlePoint - _rearBogie.SettlePoint).normalized,
				Vector3.Lerp(_frontBogie.Sample.Normal, _rearBogie.Sample.Normal, 0.5f).normalized
			)
		);

	}

}