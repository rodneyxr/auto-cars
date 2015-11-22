using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dispatcher : MonoBehaviour
{
	private List<Transform> houses;
	public float delay = 2f;
	private bool canSpawn = true;
	public GameObject carPrefab;
	// Use this for initialization
	void Awake ()
	{
		houses = new List<Transform> ();
		var tempHouses = GameObject.FindGameObjectsWithTag ("House");
		foreach (GameObject obj in tempHouses) {
			houses.Add (obj.transform);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawn ();
	}

	/// <summary>
	/// Spawn a car if the timer allows.
	/// </summary>
	private void Spawn ()
	{
		if (!canSpawn)
			return;
		StartCoroutine (DelaySpawn ());
		var house2spawn = houses [Random.Range (0, houses.Count - 1)];
		GameObject c = (GameObject)Instantiate (carPrefab, house2spawn.position, house2spawn.rotation);
		CarAI mycar = c.GetComponent<CarAI> ();
		mycar.startTravel (houses [Random.Range (0, houses.Count - 1)].position);
	}

	public void assignDestination(Player player) {
		player.startTravel (houses [Random.Range (0, houses.Count - 1)].position);
	}

	/// <summary>
	/// Delays the spawning of vehicles.
	/// </summary>
	IEnumerator DelaySpawn ()
	{
		canSpawn = false;
		yield return new WaitForSeconds (delay);
		canSpawn = true;
	}
}