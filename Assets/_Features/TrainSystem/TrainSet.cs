using System.Collections.Generic;
using UnityEngine;

public class TrainSet : MonoBehaviour {

	//======================================================================| Fields

	[SerializeField]
	private List<TrainCar> _cars = new();

	//======================================================================| Properties

	public bool IsReversed { get; set; }
	public IReadOnlyList<TrainCar> Cars => _cars;

	//======================================================================| Methods

}