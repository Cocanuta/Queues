using UnityEngine;
using System.Collections;

public class StaffAI : MonoBehaviour {

	public bool serving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, out hit, 2))
		{
			if(hit.transform.name == "Customer")
			{
				if(!serving)
				{
					StartCoroutine(Serve(hit.transform.gameObject));
				}
				else
				{

				}
			}
		}
	
	}

	public IEnumerator Serve(GameObject customer)
	{
		serving = true;
		customer.GetComponent<AIPath>().beingServed = true;
		yield return new WaitForSeconds(3);
		customer.GetComponent<AIPath>().beingServed = false;
		customer.GetComponent<AIPath> ().shopComplete = true;
		serving = false;
		yield return new WaitForSeconds (1);

	}
}
