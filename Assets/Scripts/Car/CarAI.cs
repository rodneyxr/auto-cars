using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour
{
	public Destinations destinations;
	NavMeshAgent car;

	// Use this for initialization
	void Start ()
	{
	}

    public void setDestination(Vector3 pos)
    {
		car = GetComponent<NavMeshAgent> ();
		car.speed = 8f;
        car.SetDestination(pos);
    }

}
