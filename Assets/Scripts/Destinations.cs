using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destinations : MonoBehaviour
{

	public Transform[] destinations;

	// Use this for initialization
	void Awake ()
	{
		destinations = GetComponentsInChildren<Transform> ();
	}

	public Transform GetRandomDestination ()
	{
		int index = Random.Range (0, destinations.Length - 1);
		return destinations [index];
	}
}
