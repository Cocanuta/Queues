using UnityEngine;
using System.Collections;

[System.Serializable]
public class Staff {
	
	public int staffID;			// The ID of the staff member.
	public string staffName;	// The name of the staff member.
	public float staffEnergy;	// How much energy the staff member has.

	// Creates an instance of Staff.
	public Staff (int id, string name)
	{
		staffID = id;
		staffName = name;
		staffEnergy = 100.0f;
	}

	// Sets the energy to max.
	public void setEnergyToMax()
	{
		staffEnergy = 100.0f;
	}

	// Sets the energy to 0;
	public void setEnergyToZero()
	{
		staffEnergy = 0.0f;
	}

	// Decreases the energy by 0.01.
	public void decreaseEnergy()
	{
		staffEnergy -= 0.01f;
	}

	// Increases the energy by 0.01.
	public void increaseEnergy()
	{
		staffEnergy += 0.01f;
	}
}
