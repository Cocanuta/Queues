using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	GameObject[] tills;
	public GameObject customerObject;
	public GameObject staffObject;

	public List<Staff> staff = new List<Staff>();

	public Staff selectedStaff;

	// Use this for initialization
	void Start () {

		staff.Add(new Staff(0, "Ben"));
		staff.Add(new Staff(1, "David"));
		staff.Add(new Staff(2, "Caryan"));

		tills = GameObject.FindGameObjectsWithTag ("Till");
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (selectedStaff != null)
		{
			if (Input.GetMouseButtonDown (0))
			{
				RaycastHit hitInfo = new RaycastHit();
				bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
				if (hit)
				{
					if (hitInfo.transform.gameObject.tag == "Till")
					{
						if(hitInfo.transform.gameObject.GetComponent<Till>().staff.staffName == "")
						{
							SpawnStaff (hitInfo.transform.position);
							hitInfo.transform.gameObject.GetComponent<Till>().staff = selectedStaff;
							//selectedStaff.assignTill();
						}
					}
				}
			}
		}

	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10, 10, 100, 100));
		GUILayout.BeginVertical ();

		GUILayout.Label ("Staff:");
		foreach(Staff s in staff)
		{
			if(GUILayout.Button(s.staffName))
			{
				selectedStaff = s;
			}
		}

		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}

	public void SpawnStaff(Vector3 position)
	{
		Vector3 spawnLocation = position + new Vector3 (0, 0.5f, -1);
		GameObject newStaff = Instantiate (staffObject);
		newStaff.transform.position = spawnLocation;
	}

	public void SpawnCustomer()
	{
		Vector3 spawnLocation = tills [Random.Range (0, tills.Length)].transform.position + new Vector3 (14, 0.5f, 1);
		GameObject newCustomer = Instantiate (customerObject);
		newCustomer.transform.position = spawnLocation;
	}
}
