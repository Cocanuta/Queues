using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

	public int customerID;		// The ID of the customer.
	public float customerMoney;	// The amount of money the customer will pay.

	// Creates an instance of Customer.
	public Customer (int id, float money)
	{
		customerID = id;
		customerMoney = money;
	}

}
