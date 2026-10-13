using UnityEngine;

public class TrainBogie : TrainParts {

	//======================================================================| Properties

	public RailwayCoordinate Coordinate { get; private set; }
	public RailwaySample Sample { get; private set; }

	public float Height { get; private set; }
	public float OffsetWithBody { get; private set; }

	public Vector3 SettlePoint => transform.position + Vector3.up * OffsetWithBody;

	//======================================================================| Methods

	protected override void OnInitialize() {
		Height = transform.position.y;
		OffsetWithBody = Car.Body.transform.position.y - transform.position.y;
	}

	public void MoveTo(RailwayCoordinate coordinate) {

		Coordinate = Car.IsReversed ? coordinate.Flipped : coordinate;
		Sample = coordinate.Evaluate();

		transform.SetPositionAndRotation(
			Sample.Position + Sample.Normal * Height,
			Quaternion.LookRotation(
				Sample.Tangent.normalized,
				Sample.Normal.normalized
			)
		);

	}

}