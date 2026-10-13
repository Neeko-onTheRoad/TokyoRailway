using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class TrainCar : MonoBehaviour {

	//======================================================================| Fields

	[SerializeField]
	private TrainStatus _status;

	[Header("Parts")]
	[SerializeField]
	private TrainBody _body;

	private RailwayCoordinate _coordinate;

	//======================================================================| Properties

	public TrainBody Body => _body;

	[field: SerializeField]
	public bool IsReversed { get; set; }

	public RailwayCoordinate Coordinate {
		get => _coordinate;
		set {
			_coordinate = value;
			_body.UpdatePosition();
		}
	}

	//======================================================================| Unity Methods

	private void Awake() {
		InitializeParts();
	}

	//======================================================================| Methods

	private void InitializeParts() {

		var flag =
			BindingFlags.Instance |
			BindingFlags.Public |
			BindingFlags.NonPublic;

		List<TrainParts> parts = new();
		HashSet<object> visited = new();
		Queue<object> needToInitialize = new();

		needToInitialize.Enqueue(this);

		while (needToInitialize.Count != 0) {

			var next = needToInitialize.Dequeue();

			if (visited.Contains(next)) continue;

			visited.Add(next);
			parts.Clear();
			
			parts.AddRange(next.GetType()
				.GetFields(flag)
				.Where(field => typeof(TrainParts).IsAssignableFrom(field.FieldType))
				.Select(field => field.GetValue(next) as TrainParts)
			);

			parts.AddRange(next.GetType()
				.GetProperties(flag)
				.Where(property => typeof(TrainParts).IsAssignableFrom(property.PropertyType))
				.Select(property => property.GetGetMethod().Invoke(next, null) as TrainParts)
			);

			parts.ForEach(needToInitialize.Enqueue);
			parts.ForEach(part => part.Initialize(this));

		}


	}

}