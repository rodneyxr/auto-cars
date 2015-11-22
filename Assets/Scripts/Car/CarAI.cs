using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour
{
	public Destinations destinations;
	NavMeshAgent car;

	// Use this for initialization
	void Start ()
	{
		car = GetComponent<NavMeshAgent> ();
		car.speed = 8f;
		car.SetDestination (destinations.GetRandomDestination().position);
	}

}
