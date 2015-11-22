using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour
{
	public float stopDistance = 1;
	NavMeshAgent car;
	private bool tempDest = false;
	private Vector3 initialDestination;

	void Awake ()
	{
		car = GetComponent<NavMeshAgent> ();
		car.speed = 8f;
	}

	/// <summary>
	/// Sets the destination for the car.
	/// </summary>
	/// <param name="pos">The position of the car's destination.</param>
	public void setDestination (Vector3 pos)
	{
		car.SetDestination (pos);
		tempDest = true;
	}

	public void setInitialDestination ()
	{
		car.SetDestination (initialDestination);
		tempDest = false;
	}

	public Vector3 getInitialDestination() {
		return initialDestination;
	}

	public void startTravel (Vector3 pos)
	{
		initialDestination = pos;
		setInitialDestination ();
	}

	public bool isGoingToSensor() {
		return tempDest;
	}

	void Update ()
	{
		if (tempDest)
			return;

		// check if car has reached its destination
		if (Vector3.Distance (transform.position, car.destination) < stopDistance) {
			GameObject.Destroy (gameObject);
		}
	}

}