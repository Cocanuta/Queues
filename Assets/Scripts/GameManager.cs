using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject[] tills;
	public GameObject customer;

	// Use this for initialization
	void Start () {

		tills = GameObject.FindGameObjectsWithTag ("Till");

		SpawnCustomer ();
		SpawnCustomer ();
		SpawnCustomer ();
		SpawnCustomer ();
		SpawnCustomer ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnCustomer()
	{
		Vector3 spawnLocation = tills [Random.Range (0, tills.Length)].transform.position + new Vector3 (14, 0.5f, 1);
		GameObject newCustomer = Instantiate (customer);
		newCustomer.transform.position = spawnLocation;
	}
}
