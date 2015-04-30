using UnityEngine;
using System.Collections;

public class Till : MonoBehaviour {

	public int tillID;	// The ID of the tills.
	public Staff staff;	// Which staff member is on the till.

	// Creates an instance of Till.
	public Till (int id)
	{
		tillID = id;
		staff = null;
	}

	// Assigns a staff member to the till. 0: cannot assign; 1: can assign;
	public int assignStaff (Staff st)
	{
		if (staff.Equals(null)) // If there is no staff member assigned, assign a staff member.
		{
			staff = st;
			return 1;
		}
		else // If there is a staff member assigned, you cannot assign another.
		{
			return 0;
		}
	}

	// Removes a staff member from the till. 0: cannot remove; 1: can remove;
	public int removeStaff()
	{
		if (!staff.Equals(null)) // If there is a staff member assigned, remove them.
		{
			staff = null;
			return 1;
		} 
		else // If there is not staff member assigned, you cannot remove them.
		{
			return 0;
		}
	}
	

}
