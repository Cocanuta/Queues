using UnityEngine;
using System.Collections;

[System.Serializable]
public class Till {

	public int tillID;	// The ID of the tills.
	public Staff staff;	// Which staff member is on the till.
	public GameObject tillObject;

	// Creates an instance of Till.
	public Till (int id, GameObject newObject)
	{
		tillID = id;
		staff = null;
		tillObject = newObject;
	}

}
