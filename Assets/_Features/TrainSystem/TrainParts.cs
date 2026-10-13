using UnityEngine;

public class TrainParts : MonoBehaviour {

	//======================================================================| Properties

	public TrainCar Car { get; private set; }

	//======================================================================| Methods

	protected virtual void OnInitialize() {}

	public void Initialize(TrainCar car) {
		Car = car;
		OnInitialize();
	}

}