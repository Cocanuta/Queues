using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public GameObject customerObject;
	public GameObject staffObject;

	public List<Staff> staff = new List<Staff>();
	public List<Till> tills = new List<Till> ();

	public Staff selectedStaff;

	// Use this for initialization
	void Start () {

		staff.Add(new Staff(0, "Ben", staffObject));
		staff.Add(new Staff(1, "David", staffObject));
		staff.Add(new Staff(2, "Caryan", staffObject));

		tills.Add (new Till (0, GameObject.Find ("Till")));
		tills.Add (new Till (1, GameObject.Find ("Till 1")));
		tills.Add (new Till (2, GameObject.Find ("Till 2")));
		tills.Add (new Till (3, GameObject.Find ("Till 3")));
		tills.Add (new Till (4, GameObject.Find ("Till 4")));

	
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
						foreach(Till t in tills)
						{
							if(t.tillObject == hitInfo.transform.gameObject)
							{
								if(t.staff.staffPrefab == null)
								{
									t.staff = selectedStaff;
									assignTill(selectedStaff, t);
								}
							}
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

	public void SpawnCustomer()
	{
		Vector3 spawnLocation = tills [Random.Range (0, tills.Count)].tillObject.transform.position + new Vector3 (14, 0.5f, 1);
		GameObject newCustomer = Instantiate (customerObject);
		newCustomer.transform.position = spawnLocation;
	}

	// Sets the energy to max.
	public void setEnergyToMax(Staff staff)
	{
		staff.staffEnergy = 100.0f;
	}
	
	// Sets the energy to 0;
	public void setEnergyToZero(Staff staff)
	{
		staff.staffEnergy = 0.0f;
	}
	
	// Decreases the energy by 0.01.
	public void decreaseEnergy(Staff staff)
	{
		staff.staffEnergy -= 0.01f;
	}
	
	// Increases the energy by 0.01.
	public void increaseEnergy(Staff staff)
	{
		staff.staffEnergy += 0.01f;
	}
	
	// Assign a till to the staff.
	public void assignTill(Staff staff, Till till)
	{
		if (staff.till != null) 
		{
			Destroy (GameObject.Find(staff.staffName + "Object"));
			staff.till.staff = null;
			staff.till = till;
			till.staff = staff;
		} 
		else 
		{
			staff.till = till;
		}
		Vector3 spawnLocation = till.tillObject.transform.position + new Vector3 (0, 0.5f, -1);
		GameObject newStaffObject = Instantiate (staff.staffPrefab);
		newStaffObject.transform.position = spawnLocation;
		newStaffObject.name = staff.staffName + "Object";
	}
	
	// Remove the till from the staff member.
	public void unassignTill(Staff staff)
	{
		staff.till = null;
		Destroy (GameObject.Find(staff.staffName + "Object"));
	}

	// Assigns a staff member to the till. 0: cannot assign; 1: can assign;
	public int assignStaff (Till till, Staff st)
	{
		if (till.staff.Equals(null)) // If there is no staff member assigned, assign a staff member.
		{
			till.staff = st;
			return 1;
		}
		else // If there is a staff member assigned, you cannot assign another.
		{
			return 0;
		}
	}
	
	// Removes a staff member from the till. 0: cannot remove; 1: can remove;
	public int removeStaff(Till till)
	{
		if (!till.staff.Equals(null)) // If there is a staff member assigned, remove them.
		{
			till.staff = null;
			return 1;
		} 
		else // If there is not staff member assigned, you cannot remove them.
		{
			return 0;
		}
	}
}
