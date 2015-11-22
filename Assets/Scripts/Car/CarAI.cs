using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour
{
	public float stopDistance = 1;
	NavMeshAgent car;

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
	}

	void Update ()
	{
		// check if car has reached its destination
		if (Vector3.Distance (transform.position, car.destination) < stopDistance) {
			GameObject.Destroy (gameObject);
		}
	}

}