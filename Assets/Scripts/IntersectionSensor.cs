using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntersectionSensor : MonoBehaviour
{

	public List<IntersectionSensor> sensors;
	public Vector3[] positions;

	void Awake() {
		// cache positions of sensors
		positions = new Vector3[sensors.Count];
		for (int i = 0; i < sensors.Count; i++) {
			positions[i] = sensors[i].transform.position;
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Car") {
			CarAI car = other.gameObject.GetComponent<CarAI> ();
			if (car.isGoingToSensor () || sensors.Count == 0) {
				car.setInitialDestination ();
			} else {
				car.setDestination (getClosestSensorPosition(car.getInitialDestination()));
			}
		}
	}

	private Vector3 getClosestSensorPosition (Vector3 dest)
	{
		// check for empty array
		if (positions.Length == 0)
			return Vector3.zero;

		// assume the first vector3 in the array is the shortest distance
		Vector3 minVector = positions [0];
		float minDistance = Vector3.Distance (dest, minVector);

		// loop through the rest of the array and compare their distance to find a closer sensor
		for (int i = 1; i < positions.Length; i++) {
			float currentDistance = Vector3.Distance(dest, positions[i]);
			if (currentDistance < minDistance) {
				minVector = positions [i];
				minDistance = currentDistance;
			}
		}

		return minVector;
	}

}
