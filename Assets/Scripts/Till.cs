using UnityEngine;
using System.Collections;

[System.Serializable]
public class Till {

	public int tillID;	// The ID of the tills.
	public int staffId;	// Which staff member is on the till.
	public GameObject tillObject;
	public GameObject endCustomer;
	public Vector3 endOfLine;
	public int numberOfCustomers;

	// Creates an instance of Till.
	public Till (int id, GameObject newObject)
	{
		tillID = id;
		staffId = 0;
		tillObject = newObject;
		endCustomer = null;
		endOfLine = newObject.transform.position + new Vector3 (0, 0, 1);
		numberOfCustomers = 0;
	}
}
