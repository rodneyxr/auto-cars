using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dispatcher : MonoBehaviour {
    private List<Transform> houses;

    private float delay = 2f;
    private bool canSpawn = true;

    public GameObject carPrefab;
	// Use this for initialization
	void Awake () {
        houses = new List<Transform>();
        var tempHouses = GameObject.FindGameObjectsWithTag("House");
        foreach(GameObject obj in tempHouses)
        {
            houses.Add(obj.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
	}

    private void Spawn()
    {
        if (!canSpawn)
            return;
        StartCoroutine(DelaySpawn());
        var house2spawn = houses[Random.Range(0, houses.Count - 1)];
        GameObject c = (GameObject)Instantiate(carPrefab, house2spawn.position, house2spawn.rotation);
        CarAI mycar = c.GetComponent<CarAI>();
        mycar.setDestination(houses[Random.Range(0, houses.Count - 1)].position);
    }
    IEnumerator DelaySpawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(delay);
        canSpawn = true;
    }
}