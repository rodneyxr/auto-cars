using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour
{
	public Destinations destinations;
    public float stopDistance = 1;
	NavMeshAgent car;

	// Use this for initialization
	void Awake ()
	{
		car = GetComponent<NavMeshAgent> ();
		car.speed = 8f;
	}

    public void setDestination(Vector3 pos)
    {
        car.SetDestination(pos);
    }
    void Update ()
    {
        if (Vector3.Distance(transform.position, car.destination) < stopDistance)
        {
            GameObject.Destroy(gameObject);
        }
    }

}
