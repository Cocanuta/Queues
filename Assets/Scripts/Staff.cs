using UnityEngine;
using System.Collections;

[System.Serializable]
public class Staff{
	
	public int staffID;			// The ID of the staff member.
	public string staffName;	// The name of the staff member.
	public Till till;			// Which till the staff member on.
	public float staffEnergy;	// How much energy the staff member has.
	public GameObject staffPrefab;

	// Creates an instance of Staff.
	public Staff (int id, string name, GameObject newObject)
	{
		staffID = id;
		staffName = name;
		staffEnergy = 100.0f;
		staffPrefab = newObject;
	}

}
